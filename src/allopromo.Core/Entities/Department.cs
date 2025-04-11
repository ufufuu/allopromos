using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromo.Core.Entities
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [Column("departmentId")]
        public
#nullable disable
    string departmentId
        { get; set; }

        [Column("departmentName")]
        public string departmentName { get; set; }

        [Column("departmentThumbnail")]
        public string departmentThumbnail { get; set; }

        [Column("createdDate")]
        public DateTime createdDate { get; set; }

        [Column("updatedDate")]
        public DateTime? updatedDate { get; set; }

        public virtual
#nullable enable
    ICollection<
#nullable disable
    StoreCategory>
#nullable enable
    ? Categories
        { get; set; }
    }
}
