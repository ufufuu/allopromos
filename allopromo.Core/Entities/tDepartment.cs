using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace allopromo.Core.Entities
{
    public class tDepartment
    {
        [Key]
        public string departmentId { get; set; }
        public string departmentName { get; set; }
        public string departmentThumbnail  { get; set; }
    }
}
