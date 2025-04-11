using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Infrastructure.Mapping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {



            /*
            CreateMap<Product, ProductDto>()
                .ForMember<string>((Expression<Func<ProductDto, string>>)(x => x.Name), (Action<IMemberConfigurationExpression<Product, ProductDto, string>>)(y => y.MapFrom<string>((Expression<Func<Product, string>>)(t => t.productName))))
            .ForMember<string>((Expression<Func<ProductDto, string>>)(x => x.Description), (Action<IMemberConfigurationExpression<Product, ProductDto, string>>)(y => y.MapFrom<string>((Expression<Func<Product, string>>)(t => t.productDescription))))
            .ForMember<string>((Expression<Func<ProductDto, string>>)(x => x.categoryName), (Action<IMemberConfigurationExpression<Product, ProductDto, string>>)(m => m.MapFrom<string>((Expression<Func<Product, string>>)(y => y.ProductCategory.productCategoryName))));
            .CreateMap<ProductDto, Product>()
            .ForMember<string>((Expression<Func<Product, string>>)(x => x.productName), (Action<IMemberConfigurationExpression<ProductDto, Product, string>>)(y => y.MapFrom<string>((Expression<Func<ProductDto, string>>)(t => t.Name))))
            .ForMember<string>((Expression<Func<Product, string>>)(x => x.productDescription), (Action<IMemberConfigurationExpression<ProductDto, Product, string>>)(y => y.MapFrom<string>((Expression<Func<ProductDto, string>>)(t => t.Description))))
            .ForMember<string>((Expression<Func<Product, string>>)(x => x.productId), (Action<IMemberConfigurationExpression<ProductDto, Product, string>>)(y => y.Ignore()))
            .ForMember<int>((Expression<Func<Product, int>>)(x => x.productStatus), (Action<IMemberConfigurationExpression<ProductDto, Product, int>>)(y => y.Ignore()))
            .ForMember<ProductCategory>((Expression<Func<Product, ProductCategory>>)(x => x.ProductCategory), (Action<IMemberConfigurationExpression<ProductDto, Product, ProductCategory>>)(y => y.Ignore()))
            .ForMember<Store>((Expression<Func<Product, Store>>)(x => x.Store), (Action<IMemberConfigurationExpression<ProductDto, Product, Store>>)(y => y.Ignore()));

            */
        }
    }
}
