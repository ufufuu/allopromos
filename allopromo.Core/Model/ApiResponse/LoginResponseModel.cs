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
        public LoginResponseModel(User user, string token)
        {
            //Id = user.Id;
            FirstName = user.userName;
            LastName = user.userName;
            Username = user.userPhoneNumber;
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
