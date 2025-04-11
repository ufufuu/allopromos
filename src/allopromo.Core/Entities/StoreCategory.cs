using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace allopromo.Core.Entities
{
    [Table("StoreCategories")]
    public class StoreCategory
    {
        [Key]
        [Column("categoryId")]
        public Guid storeCategoryId { get; set; }

        [Column("storeCategoryName")]
        public
#nullable disable
    string storeCategoryName
        { get; set; }

        [Column("storeCreated")]
        public DateTime created { get; set; }

        [Column("storeExpires")]
        public DateTime? expires { get; set; }

        [Column("active")]
        public bool active { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public virtual
#nullable enable
    Department? Department
        { get; set; }
    }
}
