﻿using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectRepository _projectRepository;

        private readonly IEmployeesRepository _employeesRepository;

        private readonly IHistoryActionService _historyActionService;

        public ProjectsService(IProjectRepository projectRepository, IEmployeesRepository employeesRepository,
            IHistoryActionService historyActionService)
        {
            _projectRepository = projectRepository;
            _employeesRepository = employeesRepository;
            _historyActionService = historyActionService;
        }

        public async Task<bool> AssigneProjectToEmployee(int employeeId, int projectId, bool isMaster = false)
        {
            var employeeEntity = await _employeesRepository.GetEmployeeById(employeeId);
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (employeeEntity == null || projectEntity == null)
                return false;

            var result = await _projectRepository.AssigneProjectToEmployee(employeeEntity.Id, projectEntity.Id, isMaster);

            if (result)
            {
                var resultLog = await _historyActionService.SaveHistoryActionProject(
                    string.Format("Сотрудник {0} {1} назначен на проект", employeeEntity.LastName, employeeEntity.FirstName), projectId);

                if (resultLog)
                    return true;
            }

            return result;
        }

        public async Task<bool> ChangeStatusToProject(int projectId, string newStatus)
        {
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            var oldStatus = projectEntity.GetStatusFromProject();

            if (projectEntity == null)
                return false;

            if (projectEntity.IsSameStatus(newStatus))
                return true;

            var status = GetStatus(newStatus);

            if (status == Status.UNDEFINED)
                return false;

            var result = await _projectRepository.ChangeStatusToProject(projectEntity, status);

            if (result)
            {
                var resultLog = await _historyActionService.SaveHistoryActionProject(
                    string.Format("Изменен статус с {0} на {1}", oldStatus, newStatus), projectId);

                if (resultLog)
                    return true;
            }

            return false;
        }

        public async Task<IEnumerable<ProjectVm>> GetAllProjectsVm()
        {
            var projectsEntity = await _projectRepository.GetAllProjects();
            List<ProjectVm> projectsVmList = new List<ProjectVm>();
            foreach (var projectEntity in projectsEntity)
            {
                var countEmployees = await _employeesRepository.GetCountEmployeesFromProject(projectEntity.Id);

                var projectVm = new ProjectVm
                {
                    Id = projectEntity.Id,
                    Title = projectEntity.Title,
                    Description = projectEntity.Description,
                    Status = projectEntity.GetStatusFromProject(),
                    CountEmployees = countEmployees,
                };

                projectsVmList.Add(projectVm);
            }
            return projectsVmList;
        }

        public async Task<IEnumerable<ProjectVm>> GetProjectByEmail(string email)
        {
            var employee = await _employeesRepository.GetEmployeeByEmail(email);

            if (employee == null)
                return null;

            var projectsEntity = await _projectRepository.GetProjectByEmployee(employee.Id);

            List<ProjectVm> projectsVmList = new List<ProjectVm>();
            foreach (var projectEntity in projectsEntity)
            {
                var countEmployees = await _employeesRepository.GetCountEmployeesFromProject(projectEntity.Id);

                var projectVm = new ProjectVm
                {
                    Id = projectEntity.Id,
                    Title = projectEntity.Title,
                    Description = projectEntity.Description,
                    Status = projectEntity.GetStatusFromProject(),
                    CountEmployees = countEmployees,
                };

                projectsVmList.Add(projectVm);
            }
            return projectsVmList;
        }

        public async Task<ProjectDetailsVm> GetProjectDetailsVm(int projectId)
        {
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (projectEntity == null)
                throw new Exception("Проект не найден");

            var projectDetailsVm = new ProjectDetailsVm
            {
                Id = projectEntity.Id,
                Title = projectEntity.Title,
                Description = projectEntity.Description,
                Status = projectEntity.GetStatusFromProject()
            };

            var employeeEntity = await _employeesRepository.GetMasterEmployeeByProject(projectEntity.Id);

            if (employeeEntity == null)
                projectDetailsVm.EmployeeMaster = null;
            else
            {
                projectDetailsVm.EmployeeMaster = new EmployeeMasterVm
                {
                    Id = employeeEntity.Id,
                    LastName = employeeEntity.LastName,
                    FirstName = employeeEntity.FirstName,
                    Email = employeeEntity.Email,
                    PhoneNumber = employeeEntity.PhoneNumber,
                };
            }

            var projectEmployeesEntity = await _employeesRepository.GetAllEmployeesByProject(projectEntity.Id);

            if (projectEmployeesEntity.Count() == 0)
                projectDetailsVm.Employees = null;
            else
            {
                projectDetailsVm.Employees = projectEmployeesEntity.Where(e => e.Id != employeeEntity?.Id).Select(e => new EmployeeVm
                {
                    Id = e.Id,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Patronymic = e.Patronymic,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                });
            }

            return projectDetailsVm;
        }

        public async Task<bool> UnassigneProjectToEmployee(int employeeId, int projectId)
        {
            var result = await _projectRepository.UnassigneProjectToEmployee(employeeId, projectId);

            return result;
        }

        private Status GetStatus(string status)
        {
            if (status == "ОТКРЫТО")
                return Status.OPEN;
            else if (status == "В ПРОГРЕССЕ")
                return Status.IN_PROGRESS;
            else if (status == "ЗАКРЫТО")
                return Status.CLOSED;
            else
                return Status.UNDEFINED;
        }
    }
}
