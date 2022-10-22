using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace allopromo.Core.Entities
{
    [Table("StoreCategories")]
    public class tStoreCategory
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public Guid StoreCategoryId { get; set; }

        [ForeignKey("Category")]
        public Guid storeCategoryId { get; set; }
        public string storeCategoryName { get; set; }
        //public bool hasChildren { get; set; }
        //public string storeCategoryImageUrl { get; set; }
        //public ICollection<tStore> tStores { get; set; } = new List<tStore>();
    }
}
