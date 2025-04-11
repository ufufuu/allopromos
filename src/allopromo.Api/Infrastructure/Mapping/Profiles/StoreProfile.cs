
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
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
        }
    }
}
