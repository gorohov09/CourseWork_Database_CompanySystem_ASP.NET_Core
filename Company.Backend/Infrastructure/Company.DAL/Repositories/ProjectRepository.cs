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

        public async Task<int> GetCountProjectsFromEmployee(int employeeId)
        {
            var countProjects = await _context.EmployeesProjects.Where(ep => ep.EmployeeId == employeeId)
                .CountAsync();

            return countProjects;
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllProjects()
        {
            var projectsEntityes = await _context.Projects.ToListAsync();
            return projectsEntityes;
        }

        public async Task<bool> AssigneProjectToEmployee(int employeeId, int projectId)
        {
            EmployeeProjectEntity employeeProjectEntity = new EmployeeProjectEntity()
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
            };

            _context.EmployeesProjects.Add(employeeProjectEntity);

            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<ProjectEntity> GetProjectById(int ptojectId)
        {
            var projectEntity = await _context.Projects.FirstOrDefaultAsync(p => p.Id == ptojectId);
            return projectEntity;
        }
    }
}
