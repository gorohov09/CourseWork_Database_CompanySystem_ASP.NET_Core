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
    }
}
