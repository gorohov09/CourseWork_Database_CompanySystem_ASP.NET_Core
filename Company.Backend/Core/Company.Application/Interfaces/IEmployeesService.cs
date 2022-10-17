using Company.Application.DTO;
using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeVm>> GetEmployeeVm();

        Task<EmployeeDetailsVm> GetEmployeeByIdVm(int employeeId);

        Task<IEnumerable<EmployeeVm>> GetEmployeeNotThisProject(int projectId);

        Task<bool> CreateEmployee(EmployeeVm employeeVm);

        Task<EmployeeVm> GetEmployeeByEmail(string email);
    }
}
