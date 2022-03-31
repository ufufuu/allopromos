using allopromoInfrastructure.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace allopromoInfrastructure.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExeceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong {contextFeature.Error}"); //string Extrapolation
                        //await context.Response.WriteAsync(new ErrorDetail()
                        {

                        }
                    }
                });
            });
        }
    }
}
/*
 ? * HttpStatus Code .systme.Net ?
 ? * IApplicationBuilder builder ?
? context, context Feature , 

*/