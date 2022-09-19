﻿using Company.Application.Interfaces;
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
