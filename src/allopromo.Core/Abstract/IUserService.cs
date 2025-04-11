using allopromo.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Domain;
using allopromo.Core.Entities;


namespace allopromo.Core.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(string userName, string password);

        Task<List<ApplicationUser>> GetUsersWithRolesAsync();

        Task<IList<ApplicationUser>> GetUsersByRole(string userRole);

        Task<ApplicationUser> GetUserById(string userId);

        Task<ApplicationUser> GetCurrentUser();

        Task<bool> UpdateUserRole(string roleName, string userName);

        void DeleteUser(ApplicationUser user);

        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}