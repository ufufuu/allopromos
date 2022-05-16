using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Http.Filters;
namespace allopromo.Core.Helpers
{
    // from Jsasom Watomre .Net Core JWT -- Look the ohter File
    // Jsasom Watomre .Net Core JWT
    //[AttributeUsage(AttributeTargets.Class|AttributeTargets.Methods)]?
    public class JwtBasicAuthorizeAttribute : Attribute, System.Web.Http.Filters.IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();
        public Task AuthenticateAsync(System.Web.Http.Filters.HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        /*
        public Task AuthenticateAsync(System.Web.Http.Filters.HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue value= request.Headers.Authorization;

            var parameters = authorization.Parameter;
        }
        */
        public Task ChallengeAsync(System.Web.Http.Filters.HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class BasicJwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (ApplicationUser)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result =
                    new JsonResult(new { message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized });
            }
            var headers = context.HttpContext.Request.Headers;
            var parameters = headers.Values;
        }
    }
    public class JwtMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split("").Last();
            if (token != null)
                attachUserContext(context, userService, token);
            await _next(context);
        }
        private void attachUserContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserById(userId);
            }
            catch //(Exception) vs ?
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
