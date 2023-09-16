using allopromo.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Domain;
using allopromo.Core.Application.Dto;

namespace allopromo.Core.Abstract
{
    public interface IUserService
    {
        #region Create
        Task<bool> CreateUser(string userName, string password);
        #endregion

        #region Read
        Task<string> GetUser(ApplicationUser user);

        public Task<List<UserDto>> GetUsersAsync();

        Task<IList<Microsoft.AspNetCore.Identity.IdentityUser>>GetUsersByRole(string userRole);
        public IList<ApplicationUser> GetUsersInRole(string roleName);
        public ApplicationUser GetUserRole(ApplicationUser user);
        public Task<UserDto> GetUserById(string userId);
        #endregion

        #region Update
        public void UpdateUser(ApplicationUser user);
        #endregion

        #region Delete
        public void DeleteUser(ApplicationUser user);

        //public bool ValidateUser(string userNane, string userPassword);
        //public Task<Microsoft.AspNetCore.Identity.IdentityUser> ValidateUserAsync(string userNane); 

        public bool LoginUser(Microsoft.AspNetCore.Identity.IdentityUser user);
        public System.Security.Claims.ClaimsPrincipal GetCurrentUser();

        #endregion

        #region Other Methods

        public string GenerateJwtToken(Microsoft.AspNetCore.Identity.IdentityUser user);

        //public Task<bool> UserExist(string userName);
        //Task<bool> UserExist(string userName);

        #endregion
    }
}