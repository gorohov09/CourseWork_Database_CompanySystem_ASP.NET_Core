﻿using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();

        Task<EmployeeEntity?> GetEmployeeById(int employeeId);

        Task<EmployeeEntity> GetMasterEmployeeByProject(int projectId);

        Task<IEnumerable<EmployeeEntity>> GetAllEmployeesByProject(int projectId);
    }
}
