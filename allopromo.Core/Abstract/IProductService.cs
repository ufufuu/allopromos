using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IProductService
    {
        Task<ProductCategoryDto> CreateProductCategory(ProductCategoryDto productCategoryDto);
        Task<ProductDto> CreateProductAsync(ProductDto product, string Name);
        Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId);
        Task<ProductDto> GetProductById(string productId);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryId(string id);
        
    }
}
