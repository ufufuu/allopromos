

//using allopromo.Core.Application.Dto;
//using allopromo.Api.DTOs;

using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Model
{
    public class StoreMappingProfile: Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<StoreDto, tStore>()
                .ForMember(vm => vm.storeId, map => 
                map.MapFrom(m => m.storeName));
        }
    }
}
