using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace allopromo.Core.Model
{
    public class CartItem
    {
        [Key]
        public string cartItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProductId { get; set; }
        public Entities.Product product { get; set; }
    }  
}
