﻿using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model.ApiResponse
{
    public class ApiResponseModel
    {
        public Microsoft.AspNetCore.Identity.IdentityUser userResponse { get; set; }

        public string jwtToken { get; set; }

        public string userRole { get; set; }

    }
}
