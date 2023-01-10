using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromo.Core.Entities
{
    [Table("Departments")]
    public class tDepartment
    {
        [Key]
        [Column("departmentId")]
        public string departmentId { get; set; }
        [Column("departmentName")]
        public string departmentName { get; set; }
        [Column("departmentThumbnail")]
        public string departmentThumbnail  { get; set; }
        public ICollection<tStoreCategory> Categories { get; set; }
    }
}
