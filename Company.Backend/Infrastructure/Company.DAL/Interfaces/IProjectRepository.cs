using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectEntity>> GetAllProjects();

        Task<IEnumerable<ProjectEntity>> GetProjectByEmployee(int employeeId);

        Task<int> GetCountProjectsFromEmployee(int employeeId);

        Task<bool> AssigneProjectToEmployee(int employeeId, int projectId, bool isMaster = false);

        Task<bool> UnassigneProjectToEmployee(int employeeId, int projectId);

        Task<ProjectEntity> GetProjectById(int projectId);

        Task<bool> ChangeStatusToProject(ProjectEntity projectEntity, Status newStatus);

        Task<bool> LogTimeProject(ProjectEntity projectEntity, long minutes);

        Task<int> CreateProject(string title, string description);

        Task<bool> DeleteProject(ProjectEntity projectEntity);
    }
}
