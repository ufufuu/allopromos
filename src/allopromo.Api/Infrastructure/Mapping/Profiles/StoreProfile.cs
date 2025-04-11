
using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>()
                .ForMember(x => x.CategoryName, m => m.MapFrom(y => y.Category.storeCategoryName))
                .ForMember(x => x.ProprioName, m => m.MapFrom(y => y.User.UserName))
                .ForMember(x => x.City, m => m.Ignore());
            CreateMap<StoreDto, Store>()
                .ForMember(x => x.storeCreatedOn, m => m.Ignore())
                .ForMember(x => x.storeBecomesInactiveOn, m => m.Ignore())
                //.ForMember(x => x.Category.storeCategoryName, m => m.MapFrom(y=>y.CategoryName))
                .ForPath(x => x.Category.storeCategoryName, m => m.MapFrom(y => y.CategoryName))
                //.ForMember(x => x.User.UserName, m => m.MapFrom(y => y.ProprioName));
                .ForPath(x => x.User.UserName, m => m.MapFrom(y => y.ProprioName))
                .ForMember(x => x.city, m => m.Ignore());
        }
    }
}
