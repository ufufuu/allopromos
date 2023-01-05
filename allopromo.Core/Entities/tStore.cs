using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using allopromo.Core.ValueObjects;
namespace allopromo.Core.Entities
{
    [Table("Stores")]
    public class tStore
    {
        [Key]
        public Guid storeId { get; set; }
        public string userId { get; set; }
        public string storeName { get; set; }
        public string storeDescription { get; set;}
        public DateTime storeCreatedOn{ get; set;}
        public DateTime storeBecomesInactiveOn { get; set; }
        [Required]
        public virtual int storeStatus
        {
            get
            {
                return (int)this.storeStatus; //change by StoreState and in set also
            }
            set
            {
                storeStatus = (int)value;
            }
        }
        public tStoreCategory Category { get; set; }
        public tCity City { get; set; }
        public ApplicationUser user { get; set; }

        //public string categoryId { get; set; }
        //[EnumDataType(typeof(StoreStatus))]
        //public StoreStatus StoreState { get; set; }
    }
}
