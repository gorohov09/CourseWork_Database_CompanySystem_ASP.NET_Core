﻿using AutoMapper;
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

        [HttpPost("assigneToEmployee")]
        public async Task<IActionResult> AssigneToEmployee([FromBody]AssigneProjectToEmployeeDTO model)
        {
            var result = await _projectsService.AssigneProjectToEmployee(model.EmployeeId, model.ProjectId);
            return Ok(result);
        }
    }
}
