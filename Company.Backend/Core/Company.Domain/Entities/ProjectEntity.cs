using Company.Domain.Base;

namespace Company.Domain.Entities
{
    public enum Status
    {
        OPEN,
        IN_PROGRESS,
        CLOSED,
        UNDEFINED
    }

    public class ProjectEntity : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public IEnumerable<EmployeeProjectEntity> ProjectEmployees { get; set; }

        public IEnumerable<HistoryActionEntity> HistoryActions { get; set; }

        public string GetStatusFromProject()
        {
            if (Status == Status.OPEN)
                return "ОТКРЫТО";
            else if (Status == Status.IN_PROGRESS)
                return "В ПРОГРЕССЕ";
            else if (Status == Status.CLOSED)
                return "ЗАКРЫТО";
            else
                return "НЕИЗВЕСТНЫЙ СТАТУС";
        }

        public bool IsSameStatus(string status) => GetStatusFromProject() == status ? true : false;
        
    }
}
