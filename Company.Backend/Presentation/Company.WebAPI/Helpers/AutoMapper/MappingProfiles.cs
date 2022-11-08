using AutoMapper;
using Company.Application.DTO;
using Company.Application.ViewModel;

namespace Company.WebAPI.Helpers.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeVm, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDetailsVm, EmployeeDetailsDTO>().ReverseMap();
            CreateMap<ProjectVm, ProjectDTO>().ReverseMap();
            CreateMap<ProjectDetailsVm, ProjectDetailsDTO>().ReverseMap();
            CreateMap<EmployeeMasterVm, EmployeeMasterDTO>().ReverseMap();
            CreateMap<HistoryActionVm, HistoryActionDTO>().ReverseMap();
            CreateMap<TimeProjectVm, TimeProjectDTO>().ReverseMap();    
        }
    }
}
