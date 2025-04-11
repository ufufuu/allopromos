using allopromo.Core.Domain;
using allopromo.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Helpers
{
    public class JwtBasicAuthorizeAttribute : Attribute, IAuthorizationFilter, IFilterMetadata
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if ((ApplicationUser)context.HttpContext.Items[(object)"User"] == null)
                context.Result = (IActionResult)new JsonResult((object)new
                {
                    message = "Unauthorized",
                    StatusCode = 401
                });
            ICollection<StringValues> values = context.HttpContext.Request.Headers.Values;
        }
    }
}
