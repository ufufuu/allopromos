using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace allopromo.Infrastructure.Repositories
{
    public class UserRepository    //: IEntityBaseRepository<ApplicationUser>, IUserRepository
        :IUserRepository
    {
       
        public void CreateUser(ApplicationUser user, string password)
        {
            using(var db = new AppDbContext())
            {
            }
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
        //public List<ApplicationUser> getUsers()
        //{
        //    List<ApplicationUser> users = null;
        //    using(var db = new AppDbContext())
        //    {
        //        users = db.ApplicationUsersS.ToList();
        //    }
        //    return users;
        //}
        public void Saves()
        {
            using (var db = new AppDbContext())
            {
                db.SaveChanges();
            }
        }
    }
}
