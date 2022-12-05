using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.DAL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CompanyContext _context;

        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(CompanyContext contex, ILogger<DbInitializer> logger)
        {
            _context = contex;
            _logger = logger;
        }

        public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken cancel = default)
        {
            _logger.LogInformation("Инициализация БД");

            if (RemoveBefore)
                await RemoveAsync(cancel).ConfigureAwait(false);

            await _context.Database.MigrateAsync(cancel).ConfigureAwait(false); //Запускает процесс создания БД и перевод ее в последнее состояние

            //await InitializerEmployeesAsync(cancel).ConfigureAwait(false);

            await InitializeProjectsAsync(cancel).ConfigureAwait(false);

            await InitializeRoleAndAdmin(cancel).ConfigureAwait(false);

            _logger.LogInformation("Инициализация БД выполнена успешно");
        }

        public async Task<bool> RemoveAsync(CancellationToken cancel = default)
        {
            _logger.LogInformation("Удаление БД...");

            var result = await _context.Database.EnsureDeletedAsync(cancel).ConfigureAwait(false);

            if (result)
                _logger.LogInformation("Удаление БД выполнено успешно");
            else
                _logger.LogInformation("Удаление БД не требуется");

            return result;
        }

        private async Task InitializerEmployeesAsync(CancellationToken cancel)
        {
            if (await _context.Employees.AnyAsync())
            {
                _logger.LogInformation("Инициализация сотрудников не требуется");
                return;
            }

            await using (await _context.Database.BeginTransactionAsync())
            {
                await _context.AddRangeAsync(TestData.EmployeeEntities, cancel);

                await _context.SaveChangesAsync(cancel);

                await _context.Database.CommitTransactionAsync(cancel);
            }

            _logger.LogInformation("Инициализация сотрудников выполнена успешно");
        }

        private async Task InitializeProjectsAsync(CancellationToken cancel)
        {
            if (await _context.Projects.AnyAsync())
            {
                _logger.LogInformation("Инициализация проектов не требуется");
                return;
            }

            await using (await _context.Database.BeginTransactionAsync())
            {
                await _context.AddRangeAsync(TestData.ProjectsEntities, cancel);

                await _context.SaveChangesAsync(cancel);

                await _context.Database.CommitTransactionAsync(cancel);
            }

            _logger.LogInformation("Инициализация проектов выполнена успешно");
        }

        private async Task InitializeRoleAndAdmin(CancellationToken cancel)
        {
            if (await _context.Roles.AnyAsync())
            {
                _logger.LogInformation("Инициализация ролей не требуется");
                return;
            }

            await using (await _context.Database.BeginTransactionAsync())
            {
                string adminRoleName = "admin";
                string userRoleName = "user";

                string adminEmail = "admin@mail.ru";
                string adminPassword = "123456";

                // добавляем роли
                RoleEntity adminRole = new RoleEntity { Name = adminRoleName };
                RoleEntity userRole = new RoleEntity { Name = userRoleName };
                EmployeeEntity adminUser = new EmployeeEntity
                {
                    LastName = "Администратор",
                    FirstName = "Администратор",
                    Patronymic = "Администратор",
                    Birthday = new DateTime(2002, 7, 9),
                    PhoneNumber = 89961880283,
                    Salary = 90000,
                    Email = adminEmail,
                    Password = adminPassword,
                    Role = adminRole,
                };

                await _context.AddAsync(adminRole);
                await _context.AddAsync(userRole);
                await _context.AddAsync(adminUser);

                await _context.SaveChangesAsync(cancel);

                await _context.Database.CommitTransactionAsync(cancel);
            }

            _logger.LogInformation("Инициализация проектов выполнена успешно");
        }
    }
}
