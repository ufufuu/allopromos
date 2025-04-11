using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember (x => x.categoryName, m => m.MapFrom (p => p.productCategoryName));

            CreateMap<ProductCategoryDto, ProductCategory>()
                .ForMember (x => x.productCategoryName, y => y.MapFrom (m => m.categoryName))
                .ForMember (x => x.productCategoryId, m => m.Ignore())
                .ForMember (x => x.Created, m => m.Ignore())
                .ForMember(x=>x.Created, m=>m.Ignore())
                .ForMember (x => x.updatedDate , m => m.Ignore())
                .ForMember (x => x.productCategoryId, m => m.Ignore());
        }
    }
}
