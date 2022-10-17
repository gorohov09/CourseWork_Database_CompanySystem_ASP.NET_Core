using Company.Application.DTO;
using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        private readonly IProjectRepository _projectRepository;

        private readonly IRoleRepository _roleRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IProjectRepository projectRepository,
            IRoleRepository roleRepository)
        {
            _employeesRepository = employeesRepository;
            _projectRepository = projectRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateEmployee(EmployeeVm employeeVm)
        {
            if (employeeVm == null)
                return false;

            var emploeeEntity = await _employeesRepository.GetEmployeeByEmail(employeeVm.Email);

            if (emploeeEntity != null)
                return false;

            var employeeEntity = new EmployeeEntity
            {
                LastName = employeeVm.LastName,
                FirstName = employeeVm.FirstName,
                Patronymic = employeeVm.Patronymic,
                Birthday = employeeVm.GetBirtday(),
                PhoneNumber = employeeVm.PhoneNumber,
                Email = employeeVm.Email,
                Salary = employeeVm.Salary,
                Password = employeeVm.Password,
            };

            var employeeRole = await _roleRepository.GetRoleByName("user");
            if (employeeRole != null)
                employeeEntity.Role = employeeRole;

            var employeeEntityResult = await _employeesRepository.CreateEmployee(employeeEntity);
            return employeeEntityResult.Id > 0;
        }

        public async Task<EmployeeVm> GetEmployeeByEmail(string email)
        {
            var emploeeEntity = await _employeesRepository.GetEmployeeByEmail(email);

            if (emploeeEntity == null)
                return null;

            var employeeVm = new EmployeeVm
            {
                Id = emploeeEntity.Id,
                LastName = emploeeEntity.LastName,
                FirstName = emploeeEntity.FirstName,
                Patronymic = emploeeEntity.Patronymic,
                Birthday = emploeeEntity.Birthday.ToShortDateString(),
                Email = emploeeEntity.Email,
                PhoneNumber = emploeeEntity.PhoneNumber,
                Salary = emploeeEntity.Salary,
                Age = emploeeEntity.CalculateAgeEmployee(),
            };

            return employeeVm;
        }

        public async Task<EmployeeDetailsVm> GetEmployeeByIdVm(int employeeId)
        {
            var employeeEntity = await _employeesRepository.GetEmployeeById(employeeId);
            var projectsEntity = await _projectRepository.GetProjectByEmployee(employeeId);

            if (employeeEntity == null)
                throw new ArgumentException($"Пользователь с Id: {employeeId} не найден");

            var employeesVm = new EmployeeDetailsVm
            {
                Id = employeeEntity.Id,
                LastName = employeeEntity.LastName,
                FirstName = employeeEntity.FirstName,
                Patronymic = employeeEntity.Patronymic,
                Birthday = employeeEntity.Birthday.ToShortDateString(),
                Email = employeeEntity.Email,
                PhoneNumber = employeeEntity.PhoneNumber,
                Salary = employeeEntity.Salary,
                Age = employeeEntity.CalculateAgeEmployee(),
                Projects = projectsEntity.Select(p => new ProjectVm
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Status = p.GetStatusFromProject()
                }).ToList(),
            };
            
            return employeesVm;
        }

        public async Task<IEnumerable<EmployeeVm>> GetEmployeeNotThisProject(int projectId)
        {
            var employeesByProjectEntity = await _employeesRepository.GetAllEmployeesByProject(projectId);
            var idsEmployees = employeesByProjectEntity.Select(p => p.Id).ToArray();

            var employees = await _employeesRepository.GetEmployees(idsEmployees);

            var employeesVm = employees.Select(x => new EmployeeVm
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Patronymic = x.Patronymic,
                Birthday = x.Birthday.ToShortDateString(),
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary,
                Age = x.CalculateAgeEmployee(),
                CountProjects = x.EmployeeProjects.Count(),
            });
            return employeesVm;

        }

        public async Task<IEnumerable<EmployeeVm>> GetEmployeeVm()
        {
            var employesEntity = await _employeesRepository.GetEmployees();
            var employeesVm = employesEntity.Select(x => new EmployeeVm
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Patronymic = x.Patronymic,
                Birthday = x.Birthday.ToShortDateString(),
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary,
                Age = x.CalculateAgeEmployee(),
                CountProjects = x.EmployeeProjects.Count(),
            });
            return employeesVm;
        }

        
    }
}
