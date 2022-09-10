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

        public EmployeesService(IEmployeesRepository employeesRepository, IProjectRepository projectRepository)
        {
            _employeesRepository = employeesRepository;
            _projectRepository = projectRepository;
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
                Age = CalculateAgeEmployee(employeeEntity.Birthday),
                Projects = projectsEntity.Select(p => new ProjectVm
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Status = GetStatusFromProject(p.Status)
                }).ToList(),
            };
            
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
                Age = CalculateAgeEmployee(x.Birthday),
            });
            return employeesVm;
        }

        private int CalculateAgeEmployee(DateTime date)
        {
            var age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.DayOfYear < date.DayOfYear) //на случай, если день рождения уже прошёл
                age++;
            return age;
        }

        private string GetStatusFromProject(Status status)
        {
            if (status == Status.OPEN)
                return "ОТКРЫТО";
            else if (status == Status.IN_PROGRESS)
                return "В ПРОГРЕССЕ";
            else if (status == Status.CLOSED)
                return "ЗАКРЫТО";
            else
                return "НЕИЗВЕСТНЫЙ СТАТУС";
        }
    }
}
