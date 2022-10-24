using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface IHistoryActionService
    {
        Task<bool> SaveHistoryActionProject(string title, int projectId);

        Task<IEnumerable<HistoryActionVm>> GetHistoryActionProject(int projectId);
    }
}
