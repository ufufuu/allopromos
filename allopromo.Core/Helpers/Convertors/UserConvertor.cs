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
        public static User ConvertUser(ApplicationUser appUser)
        {
            var userObj = new User();
            //userObj = (object)appUser;
            //if(appUser.UserRoles!=null)
            userObj.UserRole = (string)appUser.UserRoles?.FirstOrDefault()?.Role.Name;
            userObj.userEmail = appUser.Email;
            return userObj;
        }
        public static List<User> ConvertUsers(List<ApplicationUser> appUsers)
        {
            var listObj = new List<User>();
            foreach(var appUser in appUsers)
            {
                var user = new User();
                user.userEmail = appUser.Email;
                user.userName = appUser.UserName;
                user.userPassword = appUser.PasswordHash;
                user.userPhoneNumber = appUser.PhoneNumber;
                //user.userRoles = appUser.UserRoles;

                user.UserRole = (string)appUser.UserRoles.FirstOrDefault().Role.Name;
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