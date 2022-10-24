using Company.Domain.Base;

namespace Company.Domain.Entities
{
    public class HistoryActionEntity : Entity
    {
        public string Title { get; set; }

        public DateTime CreationTime { get; set; }

        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
