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

        public async Task<EmployeeEntity> CreateEmployee(EmployeeEntity employeeEntity)
        {
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();
            return employeeEntity;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesByProject(int projectId)
        {
            var employees = await _context.EmployeesProjects.Where(ep => ep.ProjectId == projectId)
                .Select(ep => ep.Employee)
                .ToListAsync();
            return employees;
        }

        public async Task<int> GetCountEmployeesFromProject(int projectId)
        {
            var countEmployees = await _context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectId)
                .CountAsync();
            return countEmployees;
        }

        public async Task<EmployeeEntity> GetEmployeeByEmail(string email)
        {
            var employeeEntity = await _context.Employees
                .FirstOrDefaultAsync(ep => ep.Email == email);
            return employeeEntity;
        }

        public async Task<EmployeeEntity?> GetEmployeeById(int employeeId)
        {
            var employeeEntity = await _context.Employees
                .FirstOrDefaultAsync(p => p.Id == employeeId);
            return employeeEntity;
        }
            

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees(int[] ids = null)
        {
            if (ids == null)
                return await _context.Employees.Include(p => p.EmployeeProjects).ToListAsync();
            else
                return await _context.Employees.Where(e => !ids.Contains(e.Id)).Include(p => p.EmployeeProjects).ToListAsync();
        }
            

        public async Task<EmployeeEntity> GetMasterEmployeeByProject(int projectId)
        {
            var employeeByProject = await _context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectId && ep.IsMaster == true)
                .Select(ep => ep.Employee)
                .FirstOrDefaultAsync();

            return employeeByProject;
        }
    }
}
