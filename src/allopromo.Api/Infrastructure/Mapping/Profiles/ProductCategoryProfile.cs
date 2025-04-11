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


            /*
            CreateMap<ProductCategory, ProductCategoryDto>().ForMember<string>((Expression<Func<ProductCategoryDto, string>>)(x => x.categoryName), (Action<IMemberConfigurationExpression<ProductCategory, ProductCategoryDto, string>>)(m => m.MapFrom<string>((Expression<Func<ProductCategory, string>>)(p => p.productCategoryName))));
            this.CreateMap<ProductCategoryDto, ProductCategory>().ForMember<string>((Expression<Func<ProductCategory, string>>)(x => x.productCategoryName), (Action<IMemberConfigurationExpression<ProductCategoryDto, ProductCategory, string>>)(y => y.MapFrom<string>((Expression<Func<ProductCategoryDto, string>>)(m => m.categoryName)))).ForMember<int>((Expression<Func<ProductCategory, int>>)(x => x.productCategoryId), (Action<IMemberConfigurationExpression<ProductCategoryDto, ProductCategory, int>>)(m => m.Ignore())).ForMember<DateTime>((Expression<Func<ProductCategory, DateTime>>)(x => x.Created), (Action<IMemberConfigurationExpression<ProductCategoryDto, ProductCategory, DateTime>>)(m => m.Ignore())).ForMember<DateTime>((Expression<Func<ProductCategory, DateTime>>)(x => x.updatedDate), (Action<IMemberConfigurationExpression<ProductCategoryDto, ProductCategory, DateTime>>)(m => m.Ignore())).ForMember<int>((Expression<Func<ProductCategory, int>>)(x => x.productCategoryId), (Action<IMemberConfigurationExpression<ProductCategoryDto, ProductCategory, int>>)(m => m.Ignore()));

            */
        }
    }
}
