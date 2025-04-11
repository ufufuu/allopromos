
using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class StoreCategoryProfile : Profile
    {
        public StoreCategoryProfile()
        {
            CreateMap<StoreCategory, StoreCategoryDto>()
                .ForMember(x => x.DepartmentName, m => m.Ignore());
            
            
            CreateMap<StoreCategoryDto, StoreCategory>()
                .ForMember (src => src.storeCategoryId, m=> m.Ignore())
                .ForMember ( dest => dest.storeCategoryName , m => m.Ignore())
                .ForMember (dest => dest.created, m => m.Ignore())
                .ForMember (dest => dest.expires, m => m.Ignore())
                .ForMember (dest => dest.active, m => m.Ignore())
                .ForMember (dest => dest.Stores, m => m.Ignore())
                .ForPath (dest => dest.Department.departmentName, m => m.MapFrom(src => src.DepartmentName));
        }
    }
}
