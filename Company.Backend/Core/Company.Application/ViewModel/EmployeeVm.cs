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

        public DateTime GetBirtday()
        {
            string[] array = Birthday.Split(new char[] {'.', '-', '/'}, StringSplitOptions.RemoveEmptyEntries);
            string newBirthday = $"{array[2]}-{array[1]}-{array[0]}";
            return DateTime.ParseExact(newBirthday, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
