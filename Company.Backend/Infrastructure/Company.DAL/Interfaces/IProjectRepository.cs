﻿using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectEntity>> GetAllProjects();

        Task<IEnumerable<ProjectEntity>> GetProjectByEmployee(int employeeId);

        Task<int> GetCountProjectsFromEmployee(int employeeId);
    }
}
