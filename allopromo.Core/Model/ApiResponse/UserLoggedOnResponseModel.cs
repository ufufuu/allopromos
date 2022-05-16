using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model.ApiResponse
{
    public class UserLoggedOnResponseModel
    {
        public ApplicationUser userLoggedResponse { get; set; }
        public string jwtToken { get; set; }
    }
    
}
