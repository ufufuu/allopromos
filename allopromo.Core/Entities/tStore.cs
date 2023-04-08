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
        [Column("storeId")]
        public Guid storeId { get; set; }
        //public string userId { get; set; }

        [Column("storeName")]
        public string storeName { get; set; }

        [Column("storeDescription")]
        public string storeDescription { get; set;}

        [Column("storeCreatedOn")]
        public DateTime storeCreatedOn{ get; set;}

        [Column("storeBecomesInactiveOn")]
        public DateTime storeBecomesInactiveOn { get; set; }


        /*
        [Column("categoryId")]
        public string categoryId { get; set; }*/


        public virtual tStoreCategory Category { get; set; }
        public virtual tCity City { get; set; }
        public virtual Microsoft.AspNetCore.Identity.IdentityUser User { get; set; }

       
        //[Required]
        //public virtual int storeStatus
        //{
        //    get
        //    {
        //        return (int)this.storeStatus;
        //    }
        //    set
        //    {
        //        storeStatus = (int)value;
        //    }
        //}

        //[EnumDataType(typeof(StoreStatus))]
        //public StoreStatus StoreState { get; set; }
    }
}
