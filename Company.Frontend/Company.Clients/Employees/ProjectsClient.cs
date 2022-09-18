using Company.Application.DTO;
using Company.Clients.Base;
using Company.Clients.Interfaces;
using System.Net.Http.Json;

namespace Company.Clients.Employees
{
    public class ProjectsClient : BaseClient, IProjectsClient
    {
        public ProjectsClient(HttpClient httpClient) 
            : base(httpClient, "api/projects")
        {
        }

        public async Task<bool> AssigneProjectToEmployee(int projectId, int employeeId, bool isMater = false)
        {
            var dtoModel = new AssigneProjectToEmployeeDTO
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
                IsMaster = isMater,
            };

            var response = await PostAsync("assigneToEmployee", dtoModel);
            var success = response.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>()
                .Result;

            return success;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            var projectsDTO = await GetAsync<IEnumerable<ProjectDTO>>("all");
            return projectsDTO;
        }
    }
}
