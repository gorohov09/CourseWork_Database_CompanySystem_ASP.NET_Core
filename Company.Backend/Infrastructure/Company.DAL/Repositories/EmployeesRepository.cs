using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly CompanyContext _context;

        public EmployeesRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees() =>
            await _context.Employees.ToListAsync();
    }
}
