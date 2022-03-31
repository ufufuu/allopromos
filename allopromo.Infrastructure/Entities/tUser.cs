using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace allopromo.Data.Entities
{
    public class tUser
    {
        [Required]
        [Key]
        [MaxLength(25)]
        public string userEmail { get; set; }
        [Required]
        [MaxLength(25)]
        public string userName { get; set; }
        [Required]
        [MaxLength(16)]
        public string userPassword { get; set; }
        [Required]
        [MaxLength(16)]
        public string userPhoneNumber { get; set; }

        [ForeignKey("roleId")]
        public string roleId { get; set; }
        public virtual tRole userRole { get; set; }


        //[ForeignKey("storeId")]
        //public string storeId { get; set; }
        //public virtual tStore userStore { get; set; }
    }
}
