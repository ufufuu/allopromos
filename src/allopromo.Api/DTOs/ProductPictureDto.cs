using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.DTOs
{
    public class ProductPictureDto: Api.Model.BaseApiEntityModel
    {
        public string productImageUrl { get; set; }
        public int MyProperty { get; set; }
    }
}
