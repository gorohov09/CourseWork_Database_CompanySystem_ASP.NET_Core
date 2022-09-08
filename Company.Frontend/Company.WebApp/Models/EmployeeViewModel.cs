namespace Company.WebApp.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }
    }
}
