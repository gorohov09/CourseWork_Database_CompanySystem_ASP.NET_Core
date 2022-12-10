using AutoMapper;
using Company.Application.DTO;
using Company.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        private readonly IMapper _mapper;

        public ProjectsController(IProjectsService projectsService, IMapper mapper)
        {
            _projectsService = projectsService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectsService.GetAllProjectsVm();
            var projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return Ok(projectsDTO);
        }

        [HttpGet("email/{emailEmployee}")]
        public async Task<IActionResult> GetByEmail(string emailEmployee)
        {
            var projects = await _projectsService.GetProjectByEmail(emailEmployee);
            var projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return Ok(projectsDTO);
        }

        [HttpGet("details/{projectId}")]
        public async Task<IActionResult> GetById(int projectId)
        {
            var projectDetails =  await _projectsService.GetProjectDetailsVm(projectId);
            var projectDetailsDTO = _mapper.Map<ProjectDetailsDTO>(projectDetails);
            return Ok(projectDetailsDTO);
        }

        [HttpPost("assigneToEmployee")]
        public async Task<IActionResult> AssigneToEmployee([FromBody]AssigneProjectToEmployeeDTO model)
        {
            var result = await _projectsService.AssigneProjectToEmployee(model.EmployeeId, model.ProjectId, model.IsMaster);
            return Ok(result);
        }

        [HttpPost("unassigneToEmployee")]
        public async Task<IActionResult> UnassigneToEmployee([FromBody] UnassigneProjectToEmployeeDTO model)
        {
            var result = await _projectsService.UnassigneProjectToEmployee(model.EmployeeId, model.ProjectId);
            return Ok(result);
        }

        [HttpPut("changeStatus")]
        public async Task<IActionResult> ChangeStatusById([FromBody] ChangeStatusDTO model)
        {
            var result = await _projectsService.ChangeStatusToProject(model.ProjectId, model.NewStatus, model.EmailEmployee);
            return Ok(result);
        }

        [HttpPut("logTime")]
        public async Task<IActionResult> LogTimeById([FromBody] LogTimeDTO model)
        {
            var result = await _projectsService.LogTimeById(model);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> ProjectCreate([FromBody] ProjectCreateDTO model)
        {
            var result = await _projectsService.CreateProject(model.Title, model.Description);
            return Ok(result);
        }

        [HttpDelete("delete/{projectId}")]
        public async Task<IActionResult> ProjectDelete(int projectId)
        {
            var result = await _projectsService.DeleteProject(projectId);
            return Ok(result);
        }

    }
}
