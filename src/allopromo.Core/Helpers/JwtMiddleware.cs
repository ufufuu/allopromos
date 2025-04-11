using allopromo.Core.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Helpers
{
    public class JwtMiddleware
    {
        public readonly
#nullable disable
    RequestDelegate _next;
        public readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this._next = next;
            this._appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, allopromo.Core.Abstract.IUserService userService)
        {
            string str = context.Request.Headers["Authorization"].FirstOrDefault<string>();
            string token = str != null ? ((IEnumerable<string>)str.Split("")).Last<string>() : (string)null;
            if (token != null)
                this.attachUserContext(context, userService, token);
            await this._next(context);
        }

        private void attachUserContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
                byte[] bytes = Encoding.ASCII.GetBytes(this._appSettings.Secret);
                string securityToken1 = token;
                TokenValidationParameters validationParameters = new TokenValidationParameters();
                validationParameters.ValidateIssuerSigningKey = true;
                validationParameters.IssuerSigningKey = (SecurityKey)new SymmetricSecurityKey(bytes);
                validationParameters.ValidateIssuer = false;
                validationParameters.ValidateAudience = false;
                validationParameters.ClockSkew = TimeSpan.Zero;
                SecurityToken securityToken2 =null;
                ref SecurityToken local = ref securityToken2;
                securityTokenHandler.ValidateToken(securityToken1, validationParameters, out local);
                string userId = ((JwtSecurityToken)securityToken2).Claims.First<Claim>((Func<Claim, bool>)(x => x.Type == "id")).Value;
                context.Items[(object)"User"] = (object)userService.GetUserById(userId);
            }
            catch
            {
            }
        }
    }
}

