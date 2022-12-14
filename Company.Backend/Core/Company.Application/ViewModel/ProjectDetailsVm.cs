namespace Company.Application.ViewModel
{
    public class ProjectDetailsVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// Время, потраченное на проект
        /// </summary>
        public TimeProjectVm Time { get; set; }

        /// <summary>
        /// Главный сотрудник на проекте
        /// </summary>
        public EmployeeMasterVm EmployeeMaster { get; set; }

        public IEnumerable<EmployeeVm> Employees { get; set; }

        public IEnumerable<HistoryActionVm> HistoryActions { get; set; }
    }
}
