using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class ProjectViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Колличество сотрудников")]
        public int CountEmployees { get; set; }
    }
}
