using AutoMapper;
using Company.Clients.Interfaces;
using Company.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsClient _projectsClient;

        private readonly IEmployeesClient _employeesClient;

        private readonly IMapper _mapper;

        public ProjectsController(IProjectsClient projectsClient, IEmployeesClient employeesClient, IMapper mapper)
        {
            _projectsClient = projectsClient;
            _employeesClient = employeesClient;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectsClient.GetProjects());
            var employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeesClient.GetEmployees());
            var result = new MainProjectViewModel
            {
                Projects = projects,
                Employees = employees.Select(x => new SelectListItem
                {
                    Value = $"{x.Id}",
                    Text = $"{x.LastName} {x.FirstName} {x.CountProjects}"
                }).ToList()
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AssigneEmployee(int projectId, MainProjectViewModel model)
        {
            var result = _projectsClient.AssigneProjectToEmployee(projectId, model.EmployeeId);

            return RedirectToAction("Index");
        }
    }
}
