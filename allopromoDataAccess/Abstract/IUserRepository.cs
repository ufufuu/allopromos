using allopromoDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoDataAccess.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser();
        public void CreateUser(ApplicationUser user, string password);
        public void UpdateUser();
        public void DeleteUser();
    }
}
