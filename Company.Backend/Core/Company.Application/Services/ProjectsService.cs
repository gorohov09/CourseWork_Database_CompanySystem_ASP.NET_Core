using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;

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

        public async Task<bool> AssigneProjectToEmployee(int employeeId, int projectId, bool isMaster = false)
        {
            var employeeEntity = await _employeesRepository.GetEmployeeById(employeeId);
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (employeeEntity == null || projectEntity == null)
                return false;

            var result = await _projectRepository.AssigneProjectToEmployee(employeeEntity.Id, projectEntity.Id, isMaster);

            return result;
        }

        public async Task<IEnumerable<ProjectVm>> GetAllProjectsVm()
        {
            var projectsEntity = await _projectRepository.GetAllProjects();
            List<ProjectVm> projectVmList = new List<ProjectVm>();
            foreach (var projectEntity in projectsEntity)
            {
                var employeeEntity = await _employeesRepository.GetMasterEmployeeByProject(projectEntity.Id);

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

        public async Task<ProjectDetailsVm> GetProjectDetailsVm(int projectId)
        {
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            var employeeEntity = await _employeesRepository.GetMasterEmployeeByProject(projectEntity.Id);

            var projectEmployeesEntity = await _employeesRepository.GetAllEmployeesByProject(projectEntity.Id);

            var projectDetailsVm = new ProjectDetailsVm
            {
                Id = projectEntity.Id,
                Title = projectEntity.Title,
                Description = projectEntity.Description,
                Status = projectEntity.GetStatusFromProject(),
                Employee = new EmployeeVm
                {
                    Id= employeeEntity.Id,
                    LastName = employeeEntity.LastName,
                    FirstName = employeeEntity.FirstName,
                    Patronymic = employeeEntity.Patronymic,
                    Email = employeeEntity.Email,
                    PhoneNumber = employeeEntity.PhoneNumber,
                },
                Employees = projectEmployeesEntity.Where(e => e.Id != employeeEntity.Id).Select(e => new EmployeeVm
                {
                    Id= e.Id,
                    LastName= e.LastName,
                    FirstName= e.FirstName,
                    Patronymic = e.Patronymic,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                }),
            };

            return projectDetailsVm;
        }
    }
}
