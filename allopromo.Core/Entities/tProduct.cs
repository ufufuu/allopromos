using allopromo.Core.Application.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allopromo.Core.Entities
{
    [Table("Products")]
    public class tProduct
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public virtual string storeId { get; set; }
        public int productStatus { get; set; }


        public tProductCategory ProductCategory { get; set; }
        public tStore Store { get; set; }
    }
}
