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

        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesByProject(int projectId)
        {
            var employees = await _context.EmployeesProjects.Where(ep => ep.ProjectId == projectId)
                .Select(ep => ep.Employee)
                .ToListAsync();
            return employees;
        }

        public async Task<EmployeeEntity?> GetEmployeeById(int employeeId)
        {
            var employeeEntity = await _context.Employees.FirstOrDefaultAsync(p => p.Id == employeeId);
            return employeeEntity;
        }
            

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees() =>
            await _context.Employees.Include(P => P.EmployeeProjects).ToListAsync();

        public async Task<EmployeeEntity> GetMasterEmployeeByProject(int projectId)
        {
            var employeeByProject = await _context.EmployeesProjects.Where(ep => ep.ProjectId == projectId
            && ep.IsMaster == true)
                .Select(ep => ep.Employee)
                .FirstOrDefaultAsync();

            return employeeByProject;
        }
    }
}
