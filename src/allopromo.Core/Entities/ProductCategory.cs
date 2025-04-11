using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class ProductCategory: Base.BaseEntity
    {
        [Key]
        public int productCategoryId { get; set; }
        public string productCategoryName { get; set; } = null!;
        public System.DateTime Created { get; set; }  


        //public virtual string storeId { get; set; }
        //public ICollection<tProduct> categoryProducts { get; set; }
    }
}
