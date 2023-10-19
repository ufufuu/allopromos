using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace allopromo.Core.Domain
{
    //[Table("AspNetUsers")]
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser //<string>
    {

        //public string userToken { get; set; }
        //public virtual string userRole { get; set; }
        //[Key]
        //public string hId { get; set; }

        //public override string UserName { get; set; }


        public virtual ICollection<ApplicationRole> UserRoles { get; set; }
    }
}