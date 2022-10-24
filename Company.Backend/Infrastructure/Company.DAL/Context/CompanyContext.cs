using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {

        }

        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<EmployeeProjectEntity> EmployeesProjects { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<HistoryActionEntity> HistoryActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProjectEntity>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne<EmployeeEntity>(e => e.Employee)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne<ProjectEntity>(e => e.Project)
                .WithMany(ep => ep.ProjectEmployees)
                .HasForeignKey(ep => ep.ProjectId);

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            RoleEntity adminRole = new RoleEntity {Id = 1, Name = adminRoleName };
            RoleEntity userRole = new RoleEntity {Id = 2, Name = userRoleName };
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
                RoleId = adminRole.Id,
                Id = 20
            };

            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity[] { adminRole, userRole });
            modelBuilder.Entity<EmployeeEntity>().HasData(new EmployeeEntity[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
