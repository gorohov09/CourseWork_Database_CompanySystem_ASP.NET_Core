using AutoMapper;
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
    }
}
