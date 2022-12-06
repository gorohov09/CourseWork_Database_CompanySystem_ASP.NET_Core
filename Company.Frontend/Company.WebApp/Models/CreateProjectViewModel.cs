using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class CreateProjectViewModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
