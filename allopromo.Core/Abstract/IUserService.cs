using allopromo.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Domain;
using allopromo.Core.Application.Dto;

namespace allopromo.Core.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(ApplicationUser user, string password); // ? Task CreateUser(
        Task<string> GetUser(ApplicationUser user);
        public Task<List<ApplicationUser>> GetUsersWithRoles();

        Task<IList<ApplicationUser>>GetUsersByRole(string userRole);
        public void DeleteUser(ApplicationUser user);
        public void UpdateUser(ApplicationUser user);
        public bool ValidateUser(string userNane, string userPassword);
        public bool LoginUser(ApplicationUser user);


        //public Task<bool> UserExist(string userName);
        //Task<bool> UserExist(string userName);

        public ApplicationUser GetUserIfExist(string userName);
        public IList<ApplicationUser> GetUsersInRole(string roleName);
        public ApplicationUser GetUserRole(ApplicationUser user);
        public UserDto GetUserById(string userId);
    }
}