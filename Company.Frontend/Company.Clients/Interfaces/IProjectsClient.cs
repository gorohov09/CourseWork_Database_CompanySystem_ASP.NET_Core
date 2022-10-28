using Company.Application.DTO;

namespace Company.Clients.Interfaces
{
    public interface IProjectsClient
    {
        Task<IEnumerable<ProjectDTO>> GetProjects(string email = null);

        Task<ProjectDetailsDTO> GetProjectById(int projectId);

        Task<bool> AssigneProjectToEmployee(int projectId, int employeeId, bool isMaster = false);

        Task<bool> UnassigneProjectToEmployee(int projectId, int employeeId);

        Task<bool> ChangeStatusProject(int projectId, string newStatus, string emailEmployee);
    }
}
