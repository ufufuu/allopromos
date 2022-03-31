using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model.ApiResponse
{
    public class ApiResponseModel
    {
        //public UserResponseModel userResponseModel { get; set; }

        public User userResponse { get; set; }
        public string jwtToken { get; set; }
    }
}
