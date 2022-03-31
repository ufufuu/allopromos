using System.ComponentModel.DataAnnotations;
namespace allopromo.Infrastructure.Data.Entities
{
    public class tOrder
    {
        [Key]
        public int orderId { get; set; }
        public int orderNumber { get; set; }
        public int orderDate { get;  set; }
    }
    public class tProduct
    {
        [Key]
        public int productId { get; set; }
        public int productName { get; set; }
        public virtual string storeId { get; set; }
    }
    public class tProductCategory
    {
        [Key]
        public int productCategoryId { get; set; }
        public int productCategoryName { get; set; }
        //public virtual string storeId { get; set; }
    }
    public class tStoreCategory
    {
        [Key]
        public int storeCategoryId { get; set; }
        public int storeCategorytName { get; set; }
        //public virtual string storeId { get; set; }
    }
}
