using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.ViewModel
{
    public class EmployeeVm
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

        public int CountProjects { get; set; }
    }
}
