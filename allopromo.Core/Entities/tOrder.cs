using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tOrder
    {
        [Key]
        public int orderId { get; set; }
        public int orderNumber { get; set; }
        public int orderDate { get;  set; }
    }
}
