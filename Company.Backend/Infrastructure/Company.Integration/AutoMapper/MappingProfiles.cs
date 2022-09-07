using AutoMapper;
using Company.Application.DTO;
using Company.Application.ViewModel;

namespace Company.Integration.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeVm, EmployeeDTO>().ReverseMap();
        }
    }
}
