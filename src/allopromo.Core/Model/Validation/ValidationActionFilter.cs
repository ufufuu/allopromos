using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model.Validation
{
    public class ValidationActionFilter: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            int num = actionContext.ModelState.IsValid ? 1 : 0;

        }
    }
}

