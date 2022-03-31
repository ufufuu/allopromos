using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Helpers.Convertors;
using allopromo.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Services
{
    public class ProductService :IProductService
    {
        private readonly IProductQuery _productQuery;

        public ProductService(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public async Task<ProductDto> GetProductById(string productId)
        {
            if (productId != null)
                return new ProductConvertor().ConvertDto(
                    await _productQuery.GetProductAsync(productId));
            return null;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId)
        {
            if (storeId != null)
                return (IEnumerable<ProductDto>)await _productQuery.GetProductsByStoreIdAsync(storeId);
            return null;
        }
    }
}
