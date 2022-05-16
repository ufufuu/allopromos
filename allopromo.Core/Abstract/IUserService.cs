using allopromo.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Domain;

namespace allopromo.Core.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(ApplicationUser user, string password); // ? Task CreateUser(
        Task<string> GetUser(ApplicationUser user);
        public List<ApplicationUser> GetUsers();
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
        public ApplicationUser GetUserById(string userId);
        //public User GetUserbyId(string userId);
    }
}