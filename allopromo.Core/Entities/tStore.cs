using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using allopromo.Core.Domain;
using allopromo.Core.Model;

namespace allopromo.Core.Entities
{
    [Table("Stores")]
    public class tStore
    {
        //public tStore()
        //{
        //    // ToTable("Stores");
        //}
        [Key]
        public string storeId { get; set; }

        //[ForeignKey]
        //public string userId { get; set; }

        public string storeName { get; set; }
        public string storeDescription { get; set;}
        public DateTime storeCreatedOn{ get; set;}
        public DateTime storeBecomesInactiveOn { get; set; }

        public  tStoreCategory Category { get; set; }
        public tCity City { get; set; }
        public ApplicationUser user { get; set; }

    }
}
