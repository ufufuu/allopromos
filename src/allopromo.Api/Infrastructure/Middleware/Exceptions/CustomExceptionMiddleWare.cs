using allopromo.Core.Exceptions;
using allopromo.Api.Infrastructure.Abstract;
using allopromo.Api.Infrastructure.Logging;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
namespace allopromoInfrastructure.Middleware.Exceptions
{
    public class CustomExceptionMiddleWare
    {
        //private readonly LoggerManager _logger;
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CustomExceptionMiddleWare(RequestDelegate next,
            //LoggerManager logger)
            ILogger logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(InvalidCastException ex)
            {
                throw ex;
            }
            catch(InvalidOperationException ex)
            {
                throw ex;
            }
            catch (AccessViolationException avEx)
            {
                //Serilog.Log.Error($"A new excetpion had been trhown: {avEx}");
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (System.Exception ex)
            {
                //Serilog.Log.Error($"Something went wrong - try agait {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                 statusCode = httpContext.Response.StatusCode,
                 errorMessage = "Internal Server Error from the custom middleware."
            }.ToString());
        }
        /*
         * private async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var message = exception switch
                {
                    AccessViolationException =>  "Access violation error from the custom middleware",
                    _ => "Internal Server Error from the custom middleware."
                };Use
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = message
                }.ToString());
            }
        */
    }
}
/*
 * 
 * ? RequestDelagate ? from Aspnet.core.Http
 * ? HttpContext 
 * System.Net ? HttpContext
 */