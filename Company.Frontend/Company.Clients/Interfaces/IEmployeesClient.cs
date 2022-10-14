using Company.Application.DTO;

namespace Company.Clients.Interfaces
{
    public interface IEmployeesClient
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();

        Task<EmployeeDetailsDTO> GetEmployeeDetailsById(int empId);

        Task<IEnumerable<EmployeeDTO>> GetEmployeesNotProject(int projectId);
    }
}
