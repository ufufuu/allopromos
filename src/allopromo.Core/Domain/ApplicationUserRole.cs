using allopromo.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Domain 
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole(string roleName)
          : base(roleName)
        {
        }
        public ApplicationRole()
        {
        }

        public virtual IList<ApplicationUser> Users { get; set; }

        public string roleName { get; set; }
    }
}