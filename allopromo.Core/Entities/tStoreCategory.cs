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

        [Column("categoryId")]
        public Guid storeCategoryId { get; set; }
        [Column("categoryName")]
        public string storeCategoryName { get; set; }
        public DateTime created { get; set; }
        public DateTime expires { get; set; }
        public bool active { get; set; }
        //public bool hasChildren { get; set; }
        [Column("categoryImageUrl")]
        public string storeCategoryImageUrl { get; set; }

        [Column("departmentId")]
        [ForeignKey("departmentId")]
        public string departmentId { get; set; }


        [ForeignKey("departmentId")]
        
        public virtual tDepartment Department { get; set; }
        public virtual ICollection<tStore> tStores { get; set; } = new List<tStore>();
    }
}
