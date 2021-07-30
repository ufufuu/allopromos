using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace allopromoDataAccess.Model
{
    //Model Validation -> Data Annotations in MVC
    public class User
    {
        [Required]
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
    }
}
