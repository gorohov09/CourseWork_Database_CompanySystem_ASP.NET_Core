namespace Company.Application.Interfaces
{
    public interface IHistoryActionService
    {
        Task<bool> SaveHistoryActionProject(string title, int projectId);
    }
}
