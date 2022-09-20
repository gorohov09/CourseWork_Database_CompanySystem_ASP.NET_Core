namespace Company.WebApp.Models
{
    public class AssigneToEmployeeViewModel
    {
        public bool IsMaster { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
    }
}
