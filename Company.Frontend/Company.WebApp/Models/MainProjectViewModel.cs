using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.WebApp.Models
{
    public class MainProjectViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public List<SelectListItem> Employees { set; get; }

        public int EmployeeId { get; set; }
    }
}
