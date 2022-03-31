using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace allopromo.Infrastructure.Data.Model
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        //public string userToken { get; set; }
        //public virtual string userRole { get; set; }
        [Key]
        public string Id { get; set; }
        public string userName { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}