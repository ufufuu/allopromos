using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Infrastructure.Repositories
{
    public class UserRepository //: IEntityBaseRepository<ApplicationUser>, IUserRepository
        :IUserRepository
    {
        public void CreateUser(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetBy()
        {
            throw new NotImplementedException();
        }

        public void Insert(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }
    }
}
