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
        }
    }
}
