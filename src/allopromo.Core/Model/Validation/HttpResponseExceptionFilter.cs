using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model.Validation
{
    public class HttpResponseExceptionFilter :
     Attribute,
     IActionFilter,
     IFilterMetadata,
     IOrderedFilter
    {
        public int Order { get; } = 2147483637;

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is HttpResponseException exception))
                return;
            context.Result = (IActionResult)new ObjectResult((object)exception.Message)
            {
                StatusCode = new int?(exception.statusCode)
            };
            context.ExceptionHandled = true;
        }
    }
}
