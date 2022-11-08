using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class LogTimeViewModel
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Не указано время")]
        public string LogTime { get; set; }
    }
}
