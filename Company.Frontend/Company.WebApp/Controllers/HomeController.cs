using AutoMapper;
using Company.Clients.Interfaces;
using Company.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeesClient _employeesClient;

        private readonly IMapper _mapper;

        public HomeController(IEmployeesClient employeesClient, IMapper mapper)
        {
            _employeesClient = employeesClient;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _employeesClient.GetEmployeeByEmail(User.Identity.Name);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(user);
            return View(employeeViewModel);
        }
    }
}