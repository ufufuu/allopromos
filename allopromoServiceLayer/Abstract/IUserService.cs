using allopromoDataAccess.Model;
using allopromoDataAccess.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromoServiceLayer.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUser(ApplicationUser user, string password); // ? Task CreateUser(
        Task<string> GetUser(ApplicationUser user);
        Task<IList<ApplicationUser>>GetUsersByRole(string role);
        public void DeleteUser(ApplicationUser user);
        public void UpdateUser(ApplicationUser user);
        public bool ValidateUser(LoginModel user);
    }
}
