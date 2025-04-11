using System;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        public int orderNumber { get; set; }

        public int orderDate { get; set; }

        public DateTime createOn { get; set; }

        public DateTime updateOn { get; set; }

        public string customerId { get; set; }

        public string storeId { get; set; }
    }
}
