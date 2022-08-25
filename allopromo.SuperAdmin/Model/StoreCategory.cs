using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.SuperAdmin.Model
{
    public class StoreCategory
    {
        [Key]
        public Guid storeCatId { get; set; }
        public string storeCatName { get; set; }
    }
}
