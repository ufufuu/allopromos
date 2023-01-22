using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<tDepartment, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, tDepartment>()
                .ReverseMap();
        }
    }
}
