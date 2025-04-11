using allopromo.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromo.Core.Entities
{
    //[Table("AspNetUsers")]

    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public bool isAdmin { get; set; }

        public bool isMerchant { get; set; }

        public virtual IList<ApplicationRole> UserRoles { get; set; }
    }
}