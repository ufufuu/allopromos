using allopromo.Core.Application.Dto;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Helpers.Convertors
{
    public class ProductConvertor
    {
        public  tProduct ConvertProduct(ProductDto product)
        {
            var roleObj = new tProduct();
            roleObj = (object)product as tProduct;
            return roleObj; ;
        }
        public ProductDto ConvertDto(tProduct tProduct)
        {
            var roleObj = new ProductDto();
            roleObj = (object)tProduct as ProductDto;
            return roleObj; ;
        }
        public static List<ProductDto> ConvertDto(List<ApplicationRole> roles)
        {
            var listObj = new List<ProductDto>();
            listObj = (object)roles as List<ProductDto>;
            return listObj;
        }
    }
}
