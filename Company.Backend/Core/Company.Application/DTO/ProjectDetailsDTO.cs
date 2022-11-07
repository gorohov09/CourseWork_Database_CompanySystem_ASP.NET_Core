namespace Company.Application.DTO
{
    public class ProjectDetailsDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public TimeProjectDTO Time { get; set; }
        
        public EmployeeMasterDTO EmployeeMaster { get; set; }

        public IEnumerable<EmployeeDTO> Employees { get; set; }

        public IEnumerable<HistoryActionDTO> HistoryActions { get; set; }
    }
}
