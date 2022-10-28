using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Company.DAL.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Services
{
    public class HistoryActionService : IHistoryActionService
    {
        private readonly IHistoryActionRepository _historyActionRepository;

        private readonly IProjectRepository _projectRepository;

        public HistoryActionService(IHistoryActionRepository historyActionRepository, IProjectRepository projectRepository)
        {
            _historyActionRepository = historyActionRepository;
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<HistoryActionVm>> GetHistoryActionProject(int projectId)
        {
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (projectEntity == null)
                return null;

            var historyActionsByProject = (await _historyActionRepository.GetHistoryActionProject(projectId))
                .Select(x => new HistoryActionVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreationTime = x.CreationTime,
                });

            return historyActionsByProject;
        }

        public async Task<bool> SaveHistoryActionProject(string title, int projectId)
        {
            var projectEntity = await _projectRepository.GetProjectById(projectId);

            if (projectEntity == null)
                return false;

            var historyActionEntity = new HistoryActionEntity
            {
                Title = title,
                CreationTime = DateTime.Now,
                Project = projectEntity,
            };

            var result = await _historyActionRepository.SaveHistoryActionProject(historyActionEntity);

            if (result == null)
                return false;

            return true;
        }
    }
}
