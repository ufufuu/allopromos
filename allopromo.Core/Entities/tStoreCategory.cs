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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public  int storeCategoryId { get; set; }
        public string storeCategoryName { get; set; }


        //public bool hasChildren { get; set; }
        public virtual ICollection<tStore> tStores { get; } = new List<tStore>();

        //public virtual string storeId { get; set; }
    }
}
