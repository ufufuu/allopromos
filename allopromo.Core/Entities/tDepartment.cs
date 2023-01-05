using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Entities
{
    [Table("Departments")]
    public class tDepartment
    {
        [Key]                      
        
        public string departmentId {get; set;}
        public string departmentName {get; set;}
        public string departmentThumbnail  {get; set;}

        #region Navigation Properties
        public List<tStoreCategory> categories { get; set; }
        #endregion
    }
}
