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
            var success = await response!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>();

            return success;
        }

        public async Task<bool> ChangeStatusProject(int projectId, string newStatus, string emailEmployee)
        {
            var dtoModel = new ChangeStatusDTO
            {
                ProjectId = projectId,
                NewStatus = newStatus,
                EmailEmployee = emailEmployee
            };

            var response = await PutAsync("changeStatus", dtoModel);
            var success = await response!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>();

            return success;
        }

        public async Task<bool> CreateProject(ProjectCreateDTO projectDTO)
        {
            var result = await PostAsync("create", projectDTO);
            return await result!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>();
        }

        public async Task<bool> DeleteProject(int projectId)
        {
            var response = await DeleteAsync($"delete/{projectId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ProjectDetailsDTO> GetProjectById(int projectId)
        {
            var projectDetailsDTO = await GetAsync<ProjectDetailsDTO>($"details/{projectId}");
            return projectDetailsDTO;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects(string email = null)
        {
            if (email == null)
                return await GetAsync<IEnumerable<ProjectDTO>>("all");
            else
                return await GetAsync<IEnumerable<ProjectDTO>>($"email/{email}");
        }

        public async Task<bool> LogTime(int projectId, string timeLine, string email)
        {
            var dtoModel = new LogTimeDTO
            {
                ProjectId = projectId,
                TimeLine = timeLine,
                Email = email
            };

            var response = await PutAsync("logTime", dtoModel);
            var success = await response!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>();

            return success;
        }

        public async Task<bool> UnassigneProjectToEmployee(int projectId, int employeeId)
        {
            var dtoModel = new UnassigneProjectToEmployeeDTO
            {
                ProjectId = projectId,
                EmployeeId = employeeId,
            };

            var response = await PostAsync("unassigneToEmployee", dtoModel);
            var success = await response!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<bool>();

            return success;
        }
    }
}
