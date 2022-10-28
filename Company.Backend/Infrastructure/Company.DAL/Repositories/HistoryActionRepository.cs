using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Repositories
{
    public class HistoryActionRepository : IHistoryActionRepository
    {
        private readonly CompanyContext _context;

        public HistoryActionRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoryActionEntity>> GetHistoryActionProject(int projectId)
        {
            var historyActionProject = await _context.HistoryActions
                .Where(h => h.ProjectId == projectId)
                .OrderByDescending(h => h.CreationTime)
                .ToListAsync();

            return historyActionProject;
        }

        public async Task<HistoryActionEntity> SaveHistoryActionProject(HistoryActionEntity historyActionEntity)
        {
            _context.HistoryActions.Add(historyActionEntity);
            _context.SaveChanges();
            return historyActionEntity;
        }
    }
}
