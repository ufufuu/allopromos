using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model
{
    public class ApiResponse
    {
        public Microsoft.AspNetCore.Identity.IdentityUser userResponse { get; set; }

        public string jwtToken { get; set; }

        public string userRole { get; set; }

    }
}
