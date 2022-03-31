using allopromoInfrastructure.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using allopromo.Model.Errors;
using Microsoft.AspNetCore.Http;
namespace allopromoInfrastructure.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Some went Wrong - try again{contextFeature.Error}");
                        await context.Response.WriteAsync(new allopromo.Model.Errors.ErrorDetails()
                        {
                            statusCode = context.Response.StatusCode,
                            errorMessage = "Internal Server Erreur "
                        }.ToString());
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
? WriteAsync  extension method  namespace ?
*/