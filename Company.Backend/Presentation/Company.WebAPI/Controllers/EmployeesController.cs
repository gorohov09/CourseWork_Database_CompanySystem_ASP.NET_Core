using AutoMapper;
using Company.Application.DTO;
using Company.Application.Interfaces;
using Company.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService employeesService, IMapper mapper)
        {
            _employeesService = employeesService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var employeesDTO = _mapper.Map<List<EmployeeDTO>>(await _employeesService.GetEmployeeVm());
            return Ok(employeesDTO);
        }

        [HttpGet("details/{empId}")]
        public async Task<IActionResult> GetEmployeeById(int empId)
        {
            var employeeDetailsDTO = _mapper.Map<EmployeeDetailsDTO>(await _employeesService.GetEmployeeByIdVm(empId));
            return Ok(employeeDetailsDTO);
        }

        [HttpGet("email/{empEmail}")]
        public async Task<IActionResult> GetEmployeeByEmail(string empEmail)
        {
            var employeeDetailsDTO = _mapper.Map<EmployeeDTO>(await _employeesService.GetEmployeeByEmail(empEmail));
            return Ok(employeeDetailsDTO);
        }

        [HttpGet("notProject/{projectId}")]
        public async Task<IActionResult> GetEmployeeNotProject(int projectId)
        {
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(await _employeesService.GetEmployeeNotThisProject(projectId));
            return Ok(employeesDTO);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            var employeeVm = _mapper.Map<EmployeeVm>(employeeDTO);
            var result = await _employeesService.CreateEmployee(employeeVm);
            return Ok(result);
        }
    }
}
