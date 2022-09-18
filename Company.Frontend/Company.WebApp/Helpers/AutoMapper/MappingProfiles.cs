using AutoMapper;
using Company.Application.DTO;
using Company.WebApp.Models;

namespace Company.WebApp.Helpers.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeDTO, EmployeeViewModel>().ReverseMap();
            CreateMap<EmployeeDetailsDTO, EmployeeDetailsViewModel>().ReverseMap();
            CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
            CreateMap<EmployeeMasterDTO, EmployeeMasterViewModel>().ReverseMap();
            CreateMap<ProjectDetailsDTO, ProjectDetailsViewModel>().ReverseMap();
        }
    }
}
