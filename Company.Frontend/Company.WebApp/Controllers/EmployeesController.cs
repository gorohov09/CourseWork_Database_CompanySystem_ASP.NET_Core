using Company.Clients.Interfaces;
using Company.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesClient _employeesClient;

        public EmployeesController(IEmployeesClient employeesClient)
        {
            _employeesClient = employeesClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeesDTO = await _employeesClient.GetEmployees();
            var result = employeesDTO.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Patronymic = e.Patronymic,
                Birthday = e.Birthday,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Salary = e.Salary,
            });

            return View(result);
        }
    }
}
