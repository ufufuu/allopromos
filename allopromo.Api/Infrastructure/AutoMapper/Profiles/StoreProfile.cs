using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.AutoMapper.Profiles
{
    public class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<tStore, StoreDto>();
            CreateMap<StoreDto, tStore>();
        }
    }
}
