using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectVm>> GetAllProjectsVm()
        {
            var projectsEntity = await _projectRepository.GetAllProjects();
            var projectsVm = projectsEntity.Select(p => new ProjectVm
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Status = p.GetStatusFromProject()
            });
            return projectsVm;
        }
    }
}
