﻿using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectVm>> GetAllProjectsVm();

        Task<ProjectDetailsVm> GetProjectDetailsVm(int projectId);

        Task<bool> AssigneProjectToEmployee(int employeeId, int projectId, bool isMaster = false);
    }
}
