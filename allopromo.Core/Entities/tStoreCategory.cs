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
        
        [ForeignKey("Category")]
        public Guid storeCategoryId { get; set; }
        public string storeCategoryName { get; set; }
        public DateTime created { get; set; }
        public DateTime expires { get; set; }
        public bool active { get; set; }
        //public bool hasChildren { get; set; }
        public string storeCategoryImageUrl { get; set; }
        //public ICollection<tStore> tStores { get; set; } = new List<tStore>();
    }
}
