using Company.Application.DTO;

namespace Company.Clients.Interfaces
{
    public interface IEmployeesClient
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
    }
}
