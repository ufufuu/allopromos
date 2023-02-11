using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core
{
    public class AutoMapperProfileCore : Profile
    {
        public AutoMapperProfileCore()
        {
            //CreateMap<ApplicationUser, allopromo.Core.Model.ViewModel.RegisterViewModel>()
            //    .ReverseMap();
            //CreateMap<allopromo.Core.Model.ViewModel.RegisterViewModel, ApplicationUser>()
            //    .ReverseMap();

            //CreateMap<tDepartment, DepartmentDto>()
            //    .ReverseMap();
            //CreateMap<DepartmentDto, tDepartment>()
            //    .ReverseMap();
        }
    }
}
