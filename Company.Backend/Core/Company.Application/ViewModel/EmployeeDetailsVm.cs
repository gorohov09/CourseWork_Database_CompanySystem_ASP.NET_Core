namespace Company.Application.ViewModel
{
    public class EmployeeDetailsVm
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string Birthday { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }

        public List<ProjectVm> Projects { get; set; }
    }
}
