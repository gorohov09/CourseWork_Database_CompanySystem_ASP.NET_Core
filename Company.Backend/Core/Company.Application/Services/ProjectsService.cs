using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectRepository _projectRepository;

        private readonly IEmployeesRepository _employeesRepository;

        public ProjectsService(IProjectRepository projectRepository, IEmployeesRepository employeesRepository)
        {
            _projectRepository = projectRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<bool> AssigneProjectToEmployee(int employeeId, int projectId)
        {
            var employeeEntity = await _employeesRepository.GetEmployeeById(employeeId);
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (employeeEntity == null || projectEntity == null)
                return false;

            var result = await _projectRepository.AssigneProjectToEmployee(employeeEntity.Id, projectEntity.Id);

            return result;
        }

        public async Task<IEnumerable<ProjectVm>> GetAllProjectsVm()
        {
            var projectsEntity = await _projectRepository.GetAllProjects();
            List<ProjectVm> projectVmList = new List<ProjectVm>();
            foreach (var projectEntity in projectsEntity)
            {
                var employeeEntity = await _employeesRepository.GetEmployeeByProject(projectEntity.Id);

                var employeeVm = new EmployeeVm();
                if (employeeEntity == null)
                {
                    employeeVm = null;
                }
                else
                {
                    employeeVm.Id = employeeEntity.Id;
                    employeeVm.LastName = employeeEntity.LastName;
                    employeeVm.FirstName = employeeEntity.FirstName;
                }

                var projectVm = new ProjectVm
                {
                    Id = projectEntity.Id,
                    Title = projectEntity.Title,
                    Description = projectEntity.Description,
                    Status = projectEntity.GetStatusFromProject(),
                    Employee = employeeVm
                };

                projectVmList.Add(projectVm);
            }
            return projectVmList;
        }
    }
}
