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
                configuration.CreateMap<StoreDto, tStore>();
                //.ForMember(x=>x.storeId, opt=>opt.Ignore());


                configuration.CreateMap<UserDto, ApplicationUser>();

                configuration.CreateMap<StoreCategoryDto, tStoreCategory>();
            });
            //Mapper.Initialize(configuration =>
            //{
            //    configuration.CreateMap<UserDto, ApplicationUser>();
            //});
            //Mapper.Initialize(configuration =>
            //{
            //    configuration.CreateMap<StoreCategoryDto, tStoreCategory>();
            //});
        }
    }
}
//Mapper.Initialize(x =>
//{
//    x.AddProfile<MappingProfile>();
//});
//Mapper.Configuration.AssertConfigurationIsValid(); //}