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
                configuration.CreateMap<StoreCategoryDto, tStoreCategory>();
                //.ForMember(x=>x.storeCategoryId, opt=>opt)

                configuration.CreateMap<tStoreCategory, StoreCategoryDto>();
                    //.ForMember(dest => dest.storeCategoryImageUrl, opt => opt.MapFrom(src => src.storeCategoryName));

                //configuration.CreateMap<tCity, CityDto>();

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