using Company.Application.DTO;
using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectVm>> GetAllProjectsVm();

        Task<ProjectDetailsVm> GetProjectDetailsVm(int projectId);

        Task<bool> AssigneProjectToEmployee(int employeeId, int projectId, bool isMaster = false);

        Task<bool> UnassigneProjectToEmployee(int employeeId, int projectId);

        Task<bool> ChangeStatusToProject(int projectId, string newStatus, string emailEmployee);

        Task<IEnumerable<ProjectVm>> GetProjectByEmail(string email);

        Task<bool> LogTimeById(LogTimeDTO logTimeDTO);

        Task<bool> CreateProject(string title, string description);

        Task<bool> DeleteProject(int projectId);
    }
}
