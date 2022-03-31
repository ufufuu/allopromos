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
}
