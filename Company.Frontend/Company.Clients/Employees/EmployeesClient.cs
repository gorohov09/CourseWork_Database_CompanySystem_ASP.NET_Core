using Company.Application.DTO;
using Company.Clients.Base;
using Company.Clients.Interfaces;

namespace Company.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesClient
    {
        public EmployeesClient(HttpClient httpClient) 
            : base(httpClient, "api/employees")
        {
        }

        public async Task<EmployeeDetailsDTO> GetEmployeeDetailsById(int empId)
        {
            var employeeDetailsDTO = await GetAsync<EmployeeDetailsDTO>($"details/{empId}");
            return employeeDetailsDTO;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employeesDTO = await GetAsync<IEnumerable<EmployeeDTO>>("all");
            return employeesDTO;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesNotProject(int projectId)
        {
            var employeesDTO = await GetAsync<IEnumerable<EmployeeDTO>>($"notProject/{projectId}");
            return employeesDTO;
        }
    }
}
