using allopromo.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsByStore(string storeId);
        Task<ProductDto> GetProductById(string productId);
    }
}
