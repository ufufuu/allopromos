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
        void CreateUser(ApplicationUser user, string password);
        public List<ApplicationUser> getUsers();
    }
}
