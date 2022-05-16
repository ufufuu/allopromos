using allopromo.Core.Application.Dto;
using System;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tProduct
    {
        [Key]
        public int productId { get; set; }
        public int productName { get; set; }
        public virtual string storeId { get; set; }

        public int productStatus { get; set; }
        public tProductCategory productCategory { get; set; }
    }
}
