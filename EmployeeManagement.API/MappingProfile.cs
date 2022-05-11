﻿using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
