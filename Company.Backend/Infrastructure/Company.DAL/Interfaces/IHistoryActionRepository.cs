using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IHistoryActionRepository
    {
        Task<IEnumerable<HistoryActionEntity>> GetHistoryActionProject(int projectId);

        Task<HistoryActionEntity> SaveHistoryActionProject(HistoryActionEntity historyActionEntity);
    }
}
