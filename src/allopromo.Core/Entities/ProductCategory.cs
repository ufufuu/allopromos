using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class ProductCategory
    {
        [Key]
        public int productCategoryId { get; set; }

        public string productCategoryName { get; set; }

        public DateTime Created { get; set; }

        public DateTime updatedDate { get; set; }
    }
}
