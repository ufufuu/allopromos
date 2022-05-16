using allopromo.Core.Domain;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace allopromo.Core.Helpers.Convertors
{
    // when Do We need static Classes ? along with their Methods ?
    public static class UserConvertor
    {
        public static ApplicationUser ConvertUser(ApplicationUser appUser)
        {
            var userObj = new ApplicationUser();
            //userObj = (object)appUser;
            //if(appUser.UserRoles!=null)
            userObj.UserRoles = (ICollection<ApplicationUserRole>)(appUser.UserRoles?.FirstOrDefault());
            userObj.Email = appUser.Email;
            return userObj;
        }
        public static List<ApplicationUser> ConvertUsers(List<ApplicationUser> appUsers)
        {
            var listObj = new List<ApplicationUser>();
            foreach(var appUser in appUsers)
            {
                var user = new ApplicationUser();
                user.Email = appUser.Email;
                user.UserName = appUser.UserName;
                user.PasswordHash = appUser.PasswordHash;
                user.PhoneNumber = appUser.PhoneNumber;
                //user.userRoles = appUser.UserRoles;

                user.UserRoles = (ICollection<ApplicationUserRole>)appUser.UserRoles.FirstOrDefault();
                //user.primaireRole = appUser.UserRoles.FirstOrDefault();
                //user.userRoles = (List<string>)appUser.UserRoles;
                //user.primaryRole = appUser.UserRoles.FirstOrDefault();
                listObj.Add(user);
            }
            //listObj = (object/)appUsers as List<User>;
            return listObj;
        }
    }
}