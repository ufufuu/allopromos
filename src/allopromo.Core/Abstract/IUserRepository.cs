using allopromo.Core.Domain;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IUserRepository
    {
        //public List<ApplicationUser> getUsers();
        void CreateUser(ApplicationUser user, string password);
        public void Saves();
    }
    public interface IRoleRepository
    {
    }
}
