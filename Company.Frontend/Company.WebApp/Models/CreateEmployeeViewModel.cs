using System.ComponentModel.DataAnnotations;

namespace Company.WebApp.Models
{
    public class CreateEmployeeViewModel
    {
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public string Birthday { get; set; }

        [Display(Name = "Номер телефона")]
        public long PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Зарплата")]
        public decimal Salary { get; set; }
    }
}
