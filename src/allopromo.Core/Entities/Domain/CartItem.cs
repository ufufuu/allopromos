using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Entities.Domain
{
    public class CartItem
    {
        [Key]
        public string cartItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public string ProductId { get; set; }

        public Product product { get; set; }
    }
}
