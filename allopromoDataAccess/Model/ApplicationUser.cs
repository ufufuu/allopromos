using allopromoDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromoDataAccess.Model
{
    public class ApplicationUser:Microsoft.AspNetCore.Identity.IdentityUser, IApplicationUser
    //public class ApplicationUser : TUser //, IApplicationUser
    {
        //public string appUserLogin { get; set; }
        //public string appUserLastName { get; set; }
        //public string appUserFirstName { get; set; }
        //private string _userLogin { get; set; }
        public ApplicationUser()
        {
        }
    }
}
