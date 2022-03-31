using allopromo.Core.Abstract;
using allopromo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace allopromo.Core.Services
{
    //public class UserService
    //{
    //    private readonly IUserRepo _userRepo;
    //    void CreateUser(ApplicationUser user)
    //    {
    //        _userRepo.CreateUser(user, "");
    //    }
    //    public object GetUserInfo()
    //    {
    //        using (var db = new AppDbContext())
    //        {
    //            var query = from q in
    //                     db.Users
    //                        where q.Id.Equals(9)
    //                        select q;

    //            /*var query2 = db.Users.Join(db.UserRoles,
    //                                x => x.UserName.Where(x => x.ToString() == "admin"),
    //                                userRole => db.UserRoles.Where(x => x.UserId.ToString().Equals(3)),
    //                                (t, p) => new { post = t, moe = p });*/

    //            var query23 = from user in db.Users
    //                          join userRoles in db.UserRoles on user.Id equals userRoles.UserId
    //                          join roles in db.Roles on userRoles.roleId equals roles.roleId
    //                          where userRoles.UserId.ToString().Equals(3)
    //                          where user.UserName.ToString()=="admin"
    //                          select user;
    //            return query23;
    //        }
    //    }
    //}
}
