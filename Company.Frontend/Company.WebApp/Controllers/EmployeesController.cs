using AutoMapper;
using Company.Application.DTO;
using Company.Clients.Interfaces;
using Company.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesClient _employeesClient;

        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesClient employeesClient, IMapper mapper)
        {
            _employeesClient = employeesClient;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeesDTO = await _employeesClient.GetEmployees();
            var result = _mapper.Map<IEnumerable<EmployeeViewModel>>(employeesDTO);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int empId)
        {
            var employeeDetailsDTO = await _employeesClient.GetEmployeeDetailsById(empId);
            var result = _mapper.Map<EmployeeDetailsViewModel>(employeeDetailsDTO);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            var createEmpVm = new CreateEmployeeViewModel();
            return View(createEmpVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dtoEmployee = new EmployeeDTO
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Birthday = model.Birthday,
                Salary = model.Salary,
                Password = model.Password,
            };

            var result = await _employeesClient.CreateEmployee(dtoEmployee);

            if (!result)
            {
                ModelState.AddModelError("", "Не удалось сохранить данные!");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
 