using allopromo.Api.DTOs;
using allopromo.Api.ViewModel.ViewModels;
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

            CreateMap<Department, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, Department>()
                .ReverseMap();
            CreateMap<Department, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, Department>()
                .ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
