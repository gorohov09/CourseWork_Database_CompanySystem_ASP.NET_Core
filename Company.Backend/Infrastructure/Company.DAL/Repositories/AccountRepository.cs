using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CompanyContext _context;

        public AccountRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntity> Login(string password, string email)
        {
            EmployeeEntity employee = await _context.Employees
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            return employee;
        }
    }
}
