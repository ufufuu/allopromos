

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allopromo.Core.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public string productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }

        //public virtual string storeId { get; set; }                    Why Use Shadow Navigations Properties?
        public int productStatus { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Store store { get; set; }
    }
}
