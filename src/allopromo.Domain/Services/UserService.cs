using allopromo.Domain.Abstract;
//using allopromo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Domain.Services
{
    //public class UserService: IUserService
    //{
    //    private readonly IUserRepository _userManager;

    //    //private Serilog.ILogger _logger;           // vs Microsoft Logging !
    //    public UserService()
    //    {
    //    }
    //    //public UserService(IUserRepository userRepo,
    //    //    UserManager<ApplicationUser> userManager,
    //    //    SignInManager<ApplicationUser> signInManager)
    //    //{
    //    //    _userRepo = userRepo;
    //    //    _userManager = userManager;
    //    //    _signInManager = signInManager;
    //    //}
       
    //    public bool UserExists(string userName)
    //    {
    //        bool userExists = false;
    //        try
    //        {
    //            var user =  _userManager.FindByNameAsync(userName);
    //            if (user != null)
    //                userExists = true;
    //        }
    //        catch (InvalidOperationException ex)
    //        {
    //            throw ex;
    //        }
    //        return userExists;
    //    }

    //    Task<bool> IUserService.CreateUser(ApplicationUser user, string password)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    void IUserService.DeleteUser(ApplicationUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<string> IUserService.GetUser(ApplicationUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    ApplicationUser IUserService.GetUserById(string userId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    ApplicationUser IUserService.GetUserIfExist(string userName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    string IUserService.GetUserRole(ApplicationUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    List<ApplicationUser> IUserService.GetUsers()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<IList<ApplicationUser>> IUserService.GetUsersByRole(string userRole)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IList<ApplicationUser> IUserService.GetUsersInRole(string roleName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    bool IUserService.LoginUser(ApplicationUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    void IUserService.UpdateUser(ApplicationUser user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    bool IUserService.ValidateUser(string userNane, string userPassword)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public interface IUserRepository
    //{
    //    bool FindByNameAsync(string userName);
    //}
}
