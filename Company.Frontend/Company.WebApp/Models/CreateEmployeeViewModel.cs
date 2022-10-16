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
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Зарплата")]
        public decimal Salary { get; set; }
    }
}
