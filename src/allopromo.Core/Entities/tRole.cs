using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromo.Data.Entities
{
    [Table("Role")]
    public class tRole
    {
        //[Column("Id")]
        [Key]
        public string roleId { get; set; }
        public string roleName { get; set; }
        public tRole()
        {
        }
        
    }
}
