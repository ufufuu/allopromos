using allopromoDataAccess.Abstract;
using allopromoDataAccess.Model;
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
        public UserService(IUserRepository userRepo, UserManager<ApplicationUser> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
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
