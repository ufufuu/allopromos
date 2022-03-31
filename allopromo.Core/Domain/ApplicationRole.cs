using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Domain
{
    public class ApplicationRole: IdentityRole//? rmv <string ?
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
