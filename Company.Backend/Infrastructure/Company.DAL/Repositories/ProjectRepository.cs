using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly CompanyContext _context;

        public ProjectRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectEntity>> GetProjectByEmployee(int employeeId)
        {
            var projectsByEmployee = await _context.EmployeesProjects.Where(ep => ep.EmployeeId == employeeId)
                .Select(ep => ep.Project)
                .ToListAsync();

            return projectsByEmployee;
        }
    }
}
