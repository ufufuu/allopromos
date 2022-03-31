using allopromo.Model.Errors;
using allopromoInfrastructure.Abstract;
using allopromoInfrastructure.Logging;
using allopromoInfrastructure.Middleware.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace allopromo.Extensions
{
    public static class ExceptionMiddleWareExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseMiddleware<CustomExceptionMiddleWare>();
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, 
            LoggerManager logger)
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
                        //logger.LogError($"Somehting Went Wrong:{contextFeature.Error}");
                        Serilog.Log.Logger.Error($"Somethin Went Wring :{contextFeature.Error}");
                        
                        await context.Response.WriteAsync(new ErrorDetails()
                        //await context.R
                        {
                            statusCode = context.Response.StatusCode,
                            errorMessage = "Internal Server ErroRRr"
                        }.ToString());
                    }
                });
            });
        }
    }
}
/*
 * WriteAsync => aspnet.Core.Http.WriteAsync()
 */
