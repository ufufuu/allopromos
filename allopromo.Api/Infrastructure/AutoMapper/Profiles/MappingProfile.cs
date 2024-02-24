using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Infrastructure.Mapper.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<IdentityUser, RegisterViewModel>()
                .ReverseMap();
            CreateMap<RegisterViewModel, IdentityUser>()
                .ReverseMap();

            CreateMap<IdentityUser, RegisterViewModel>()
                .ReverseMap();
            CreateMap<RegisterViewModel, IdentityUser>()
                .ReverseMap();

            CreateMap<tDepartment, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, tDepartment>()
                .ReverseMap();
            CreateMap<tDepartment, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, tDepartment>()
                .ReverseMap();
            CreateMap<tProduct, ProductDto>().ReverseMap();
            CreateMap<ProductDto, tProduct>().ReverseMap();
        }
    }
}
