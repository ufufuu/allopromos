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
        //private readonly ILazyLoader _lazyLoader;

        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //[ForeignKey("Category")]

        [Column("categoryId")]
        public Guid storeCategoryId { get; set; }

        [Column("storeCategoryName")]
        public string storeCategoryName { get; set; }

        [Column("storeCreated")]
        public DateTime created { get; set; }

        [Column("storeExpires")]
        public DateTime? expires { get; set; }

        [Column("active")]
        public bool active { get; set; }

        //private ICollection <tStore> _books;

        public virtual ICollection<Store> stores
        {
            get;// => _lazyLoader.Load(this, ref _books);
            set;// => _books = value;
        }
        public virtual Department? Department { get; set; }
        public StoreCategory()
        {}

        //public bool hasChildren { get; set; }
        //[Column("categoryImage")]
        //public string storeCategoryImageUrl { get; set; }

        //public tStoreCategory(ILazyLoader lazyLoad)
        //{
        //    _lazyLoader = lazyLoad;
        //}
    }
}
