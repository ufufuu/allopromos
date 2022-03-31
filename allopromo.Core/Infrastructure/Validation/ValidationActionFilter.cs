using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Model.Validation
{

    public class ValidationActionFilter:ActionFilterAttribute //aspnetCore.Mvc.Filters
    {
        ///public override void OnActionExecuting(ActionExecutingContext actionContext)
        //public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext actionContext)
        { 
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                //actionContext.HttpContext.Response = actionContext.HttpContext.Request
                  //  .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
}
