using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tProductCategory
    {
        [Key]
        public int productCategoryId { get; set; }
        public int productCategoryName { get; set; }
        //public virtual string storeId { get; set; }
    }
}
