﻿using Company.Application.DTO;
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

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employeesDTO = await GetAsync<IEnumerable<EmployeeDTO>>("all");
            return employeesDTO;
        }
    }
}
