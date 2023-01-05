using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Admin.Models.Dto
{
    public class DepartmentDto
    {
        public string DepartmentId { get; set; }
        [Required(ErrorMessage ="Name is Required for Department ")]
        [MinLength(16, ErrorMessage =" Lenght should be 16")]
        public string departmentName { get; set; }
    }
}
