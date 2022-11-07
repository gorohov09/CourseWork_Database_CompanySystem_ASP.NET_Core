using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class ProjectDetailsViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Тема")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Главный по проекту")]
        public EmployeeMasterViewModel EmployeeMaster { get; set; }

        [Display(Name = "Другие сотрудники, выполняющие проект")]
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        [Display(Name = "История действий")]
        public IEnumerable<HistoryActionViewModel> HistoryActions { get; set; }

        [Display(Name = "Время, потраченное на проект")]
        public TimeProjectViewModel Time { get; set; }
    }
}
