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
            var result = new MainProjectViewModel
            {
                Projects = projects.ToList(),
            };

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int projectId)
        {
            var projectDetailsDTO = await _projectsClient.GetProjectById(projectId);
            var result = _mapper.Map<ProjectDetailsViewModel>(projectDetailsDTO);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AssigneEmployee(int projectId, bool isMaster, MainProjectViewModel model)
        {
            var result = await _projectsClient.AssigneProjectToEmployee(projectId, model.EmployeeId, isMaster);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AssigneToEmployee(int projectId, bool isMaster = false)
        {
            var assigneEmployeeViewModel = new AssigneToEmployeeViewModel
            {
                Employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeesClient.GetEmployeesNotProject(projectId)).ToList(),
                IsMaster = isMaster
            };

            ViewBag.ProjectId = projectId;

            return View(assigneEmployeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssigneToEmployee(int projectId, int employeeId, bool isMaster = false)
        {
            var result = await _projectsClient.AssigneProjectToEmployee(projectId, employeeId, isMaster);

            return RedirectToAction("Details", new {projectId = projectId});
        }

        [HttpPost]
        public async Task<IActionResult> UnassigneToEmployee(int projectId, int employeeId)
        {
            var result = await _projectsClient.UnassigneProjectToEmployee(projectId, employeeId);

            return RedirectToAction("Details", new { projectId = projectId });
        }
    }
}
