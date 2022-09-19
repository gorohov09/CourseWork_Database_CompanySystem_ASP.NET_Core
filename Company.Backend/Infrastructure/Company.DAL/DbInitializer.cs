using Company.DAL.Context;
using Company.DAL.Interfaces;
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

            await InitializerEmployeesAsync(cancel).ConfigureAwait(false);

            await InitializeProjectsAsync(cancel).ConfigureAwait(false);

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
            //if (await _context.Projects.AnyAsync())
            //{
            //    _logger.LogInformation("Инициализация проектов не требуется");
            //    return;
            //}

            await using (await _context.Database.BeginTransactionAsync())
            {
                await _context.AddRangeAsync(TestData.ProjectsEntities, cancel);

                await _context.SaveChangesAsync(cancel);

                await _context.Database.CommitTransactionAsync(cancel);
            }

            _logger.LogInformation("Инициализация проектов выполнена успешно");
        }
    }
}
