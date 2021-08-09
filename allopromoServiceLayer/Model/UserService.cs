using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
using allopromoDataAccess.Model.ViewModel;
using allopromoServiceLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromoServiceLayer.Model
{
   public class UserService : IUserService // OU Domain au lieu de Model ?
    {
        // Repository Pattern ?
        private readonly IUserRepository _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(IUserRepository userRepo, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private async Task<bool> UserExist(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user!=null)
            {
               // var login = await SignInManager.SignInAsync(user, isPersistent:false, 
                 //   rememberBrowser:false);
            }
            return true;
            return false;
        }
        public bool ValidateUser(LoginModel user)
        {
            var appUser = new ApplicationUser { UserName = user.userName };
            if (UserExist(user.userName).Result)
            {
                var login = _signInManager.SignInAsync(appUser, isPersistent: false);
                if(login!=null)
                return true;
                return false;
            }
            return false;
        }
        public async Task<bool> CreateUser(ApplicationUser user, string password)
        {
            //Code Coverage ?
            //Input Possibilities
            //User is Invalid, 
            //User is Valid , password is Invalid - user is Valid, passwd is Valid - 
            try
            {
                var result= await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    //AddUserRole(user, "Users");
                    //var currentUser = _userManager.FindByNameAsync(user.UserName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "SU");
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
        private void AddUserRole(ApplicationUser user, string roleName)
        {
            _userManager.AddToRoleAsync(user, roleName);
        }
        public void CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        void IUserService.DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<IList<ApplicationUser>> IUserService.GetUsersByRole(string role)
        {
            return _userManager.GetUsersInRoleAsync(role);
        }
        Task<string> IUserService.GetUser(ApplicationUser user)
        {
            return _userManager.GetUserNameAsync(user);
        }
        void IUserService.UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
