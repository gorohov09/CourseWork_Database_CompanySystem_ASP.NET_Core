using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;

namespace Company.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
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
    }
}
