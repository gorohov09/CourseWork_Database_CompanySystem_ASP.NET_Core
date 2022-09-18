﻿using Company.Application.DTO;

namespace Company.Clients.Interfaces
{
    public interface IProjectsClient
    {
        Task<IEnumerable<ProjectDTO>> GetProjects();

        Task<ProjectDetailsDTO> GetProjectById(int projectId);

        Task<bool> AssigneProjectToEmployee(int projectId, int employeeId, bool isMaster = false);
    }
}
