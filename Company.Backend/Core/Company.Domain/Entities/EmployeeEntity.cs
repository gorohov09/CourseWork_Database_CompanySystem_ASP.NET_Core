using Company.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Entities
{
    public class EmployeeEntity : Entity
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        [Column(TypeName = "decimal(18,2)")] //Указание типа, который храним в БД
        public decimal Salary { get; set; }

        public IEnumerable<EmployeeProjectEntity> EmployeeProjects { get; set; }

        public int CalculateAgeEmployee()
        {
            var age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear) //на случай, если день рождения уже прошёл
                age++;
            return age;
        }
    }
}
