using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Domain
{
    public class ApplicationRole: IdentityRole <string>
    {
        public ApplicationRole(string roleName) : base(roleName)
        {}
        public ApplicationRole()
        {}

        //public string roleId { get; set; }
        //public string roleName { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }


        public static explicit operator ApplicationRole(IdentityRole v)
        {
            ApplicationRole role = new ApplicationRole { Name = v.Name };
            return role;
        }
    }
}
