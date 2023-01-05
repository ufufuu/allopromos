using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using AutoMapper;
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
                configuration.CreateMap<StoreDto, tStore>()
                .ForMember(x=>x.storeId, opt=>opt.Ignore());

                configuration.CreateMap<UserDto, ApplicationUser>();
                configuration.CreateMap<ApplicationUser, UserDto>();

                configuration.CreateMap<tStoreCategory, StoreCategoryDto>();
                configuration.CreateMap<StoreCategoryDto, tStoreCategory>();

                configuration.CreateMap<tDepartment, DepartmentDto>()
                .ForMember(dest => dest.departmentId, opt => opt.MapFrom(src => src.departmentId));
                configuration.CreateMap<DepartmentDto, tDepartment>()
                .ForMember(dest => dest.departmentId, opt => opt.MapFrom(src => src.departmentId));


                configuration.CreateMap<DepartmentDto, tDepartment>();

                //.ForMember(x => x.storeCategoryId, opt => opt.Ignore());
                //.ForMember(x => x.departmentId, opt => opt.Ignore());


                configuration.CreateMap<CityDto, tCity>()
                    .ForMember(x => x.cityGpsLatitude, opt => opt.Ignore())
                    .ForMember(x => x.cityGpsLongitude, opt => opt.Ignore())
                    .ForMember(x => x.countryId, opt => opt.Ignore());

            });
            
        }
    }
}
//Mapper.Initialize(x =>
//{
//    x.AddProfile<MappingProfile>();
//});
//Mapper.Configuration.AssertConfigurationIsValid(); //}