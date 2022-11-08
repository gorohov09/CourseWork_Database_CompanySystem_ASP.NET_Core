using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class TimeProjectViewModel
    {
        [Display(Name = "д.")]
        public int Days { get; set; }

        [Display(Name = "ч.")]
        public int Hours { get; set; }

        [Display(Name = "м.")]
        public int Minutes { get; set; }
    }
}
