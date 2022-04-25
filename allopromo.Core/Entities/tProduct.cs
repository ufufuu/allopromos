using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tProduct
    {
        [Key]
        public int productId { get; set; }
        public int productName { get; set; }
        public virtual string storeId { get; set; }
    }
}
