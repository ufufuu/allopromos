using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
     
namespace allopromo.Model.Validation
{
    public class HttpResponseExceptionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = exception.statusCode,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
