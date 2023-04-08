using allopromo.Api.ViewModel.ViewModels;
using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(configuration =>
            {
                configuration.ValidateInlineMaps = false;

                configuration.CreateMap<StoreDto, tStore>();
                //.ForMember(x=>x.storeId, opt=>opt.Ignore());

                configuration.CreateMap<tStore, StoreDto>();
                //.ForMember(x => x.storeId, opt => opt.Ignore());

                configuration.CreateMap<UserDto, ApplicationUser>();

                configuration.CreateMap<IdentityUser, UserDto>();
                
                configuration.CreateMap<StoreCategoryDto, tStoreCategory>();

                //.ForMember(x=>x.storeCategoryId, opt=>opt)

                configuration.CreateMap<tStoreCategory, StoreCategoryDto>();

                //.ForMember(dest => dest.storeCategoryImageUrl, opt => opt.MapFrom(src => src.storeCategoryName));

                //configuration.CreateMap<tCity, CityDto>();

                configuration.CreateMap<CityDto, tCity>()
                    .ForMember(x => x.cityGpsLatitude, opt => opt.Ignore())
                    .ForMember(x => x.cityGpsLongitude, opt => opt.Ignore());
                    //.ForMember(x => x.countryId, opt => opt.Ignore());
            });
        }
    }
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IdentityUser, RegisterViewModel>()
                .ReverseMap();
            CreateMap<RegisterViewModel, IdentityUser>()
                .ReverseMap();

            CreateMap<tDepartment, DepartmentDto>()
                .ReverseMap();
            CreateMap<DepartmentDto, tDepartment>()
                .ReverseMap();
        }
    }
}


//Mapper.Initialize(x =>
//{
//    x.AddProfile<MappingProfile>();
//});
//Mapper.Configuration.AssertConfigurationIsValid(); //}