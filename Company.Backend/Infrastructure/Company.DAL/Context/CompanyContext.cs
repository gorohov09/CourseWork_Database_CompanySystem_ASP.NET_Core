using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Context
{
    public class CompanyContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {

        }
    }
}
