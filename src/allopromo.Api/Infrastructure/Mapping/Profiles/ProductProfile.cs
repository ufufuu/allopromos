using allopromo.Api.DTOs;
using allopromo.Core.Entities;
using AutoMapper;
 
namespace allopromo.Api.Infrastructure.Mapping.Profiles
{


    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.productName, y => y.MapFrom(t => t.Name))
                .ForMember(x => x.productDescription, y => y.MapFrom(t => t.Description))
                .ForMember(x => x.productId, y => y.Ignore())
                .ForMember(x => x.productStatus, y => y.Ignore())
                //.ForPath(x => x.ProductCategory.productCategoryName, y => y.MapFrom( t=>t.categoryName))
                .ForMember(x => x.Store,  y => y.Ignore());
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Name, y => y.MapFrom(t => t.productName))
                .ForMember(x => x.Description, y => y.MapFrom(t => t.productDescription));
                //.ForPath(x =>x.categoryName, m => m.MapFrom(y => y.ProductCategory.productCategoryName));
        }
    }
}