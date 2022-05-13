using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeForCreationDto, Employee>();
        }
    }
}
