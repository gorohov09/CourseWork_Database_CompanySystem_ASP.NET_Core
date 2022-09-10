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
        }
    }
}
