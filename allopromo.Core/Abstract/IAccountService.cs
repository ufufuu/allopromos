using allopromo.Core.Domain;
using allopromo.Core.Model;
using allopromo.Core.Model.ApiResponse;
using System;
using static allopromo.Core.Model.AccountService;
namespace allopromo.Core.Abstract
{
    public class UserAuthenticateEventArgs : EventArgs { 
    }
    public interface IAccountService
    {
        //public delegate void UserAuthenticatedEventHandler(object source, EventArgs e);

        public string generateJwtToken(Microsoft.AspNetCore.Identity.IdentityUser user); 

        // method for handling event without any data
        public event UserAuthenticatedEventHandler userAuthenticated;

        //public event EventHandler<UserAuthenticateEventArgs> onUserAuthenticated;

        public delegate UserAuthenticateEventArgs onUserAuthenticates();
        public void OnUserAuthenticate(string userName);
        public void OnUserAuthenticated();

        abstract LoginResponseModel Authenticate(ApplicationUser login);


        //abstract LoginResponseModel Authenticate(LoginViewModel login);
    }
}
/*The EventArgs class is the base type for all event data classes. ... The EventHandler delegate includes
 * the EventArgs class as a parameter. When you want to create a customized event data class, 
 * create a class that derives from EventArgs, and then provide any members needed to pass data that 
 * is related to the event*/