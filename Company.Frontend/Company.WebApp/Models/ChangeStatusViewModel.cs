using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class ChangeStatusViewModel
    {
        public int ProjectId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string OldStatus { get; set; }

        [Display(Name = "Новый статус")]
        public string NewStatus { get; set; }
    }
}
