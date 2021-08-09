using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromoDataAccess.Model
{
    [Table("Stores")]
    public class Store
    {
        public Store()
        {
           // ToTable("Stores");
        }
        [Column("Id")]
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string storeDescription { get; set; }
        //public virtual ApplicationUser storeOwner { get; set; }

    }
}
