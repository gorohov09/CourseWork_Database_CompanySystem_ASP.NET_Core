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
            var result = new MainProjectViewModel();

            IEnumerable<ProjectViewModel> projects = null;

            if (User.IsInRole("admin"))
            {
                result.Projects = _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectsClient.GetProjects()).ToList();
            }
            else
            {
                result.Projects = _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectsClient.GetProjects(User.Identity.Name)).ToList();
            }

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

            return result ? RedirectToAction("Index") : NotFound();
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

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(int projectId)
        {
            var model = new ChangeStatusViewModel
            {
                ProjectId = projectId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ChangeStatusViewModel model)
        {
            var email = User.Identity!.Name;
            var result = await _projectsClient.ChangeStatusProject(model.ProjectId, model.NewStatus, email);

            if (!result)
            {
                ModelState.AddModelError("", "Не удалось сохранить данные! Возможно неверно написан статус задачи");
                return View(model);
            }

            return RedirectToAction("Details", new { projectId = model.ProjectId });
        }

        [HttpGet]
        public async Task<IActionResult> LogTime(int projectId)
        {
            var model = new TimeProjectViewModel
            {
                ProjectId = projectId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogTimes(ChangeStatusViewModel model)
        {
            var email = User.Identity!.Name;
            var result = await _projectsClient.ChangeStatusProject(model.ProjectId, model.NewStatus, email);

            if (!result)
            {
                ModelState.AddModelError("", "Не удалось сохранить данные! Возможно неверно написан статус задачи");
                return View(model);
            }

            return RedirectToAction("Details", new { projectId = model.ProjectId });
        }
    }
}
