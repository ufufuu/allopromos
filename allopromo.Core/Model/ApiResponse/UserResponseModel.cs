using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model.ApiResponse
{
    public class UserResponseModel//:<T> where T:class
    {
        public string userLogin { get; set; }
        public string userName { get; set; }
        public List<string> userRoles { get; set; }
        public string userRole { get; set; }
    }
    public class UserLoggedResponseModel
    {
        //public UserResponseModel userResponseModel { get; set; }
        public ApplicationUser userResponse { get; set; }
        public string jwtToken { get; set; }
    }




    //public class ResponseModel
    //{

    //}
}
