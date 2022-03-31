using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace allopromo.Core.Entities
{
    [Table("Stores")]
    public class tStore
    {
        public tStore()
        {
            // ToTable("Stores");
        }
        [Key]
        public string storeId { get; set; }
        public string userId { get; set; }
        public string storeName { get; set; }
        public string storeDescription { get; set;}
        public DateTime storeCreatedOn{ get; set;}
        public DateTime storeBecomesInactiveOn { get; set; }
        public virtual tStoreCategory storeCategory { get; set; }
    }
}
