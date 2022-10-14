namespace Company.Domain.Entities
{
    public class EmployeeProjectEntity
    {
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }

        /// <summary>
        /// Является ли сотрудник, главным на проекте
        /// </summary>
        public bool IsMaster { get; set; }
    }
}
