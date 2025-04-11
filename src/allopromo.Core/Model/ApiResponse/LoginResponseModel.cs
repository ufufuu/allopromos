using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model.ApiResponse
{
    public class LoginResponseModel
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public LoginResponseModel(ApplicationUser user, string token)
        {
            //Id = user.Id;
            FirstName = user.UserName;
            LastName = user.UserName;
            Username = user.PhoneNumber;
            //Role ?
            Token = token;
        }
    }
    public class AuthenticateRequest
    {

    }
    public class AuthenticateResponse
    {

    }
}
