using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.ToolKit
{
    public class JwtManager
    {
        private static string secret = "db30Isj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iT0dtVWJG8abWvB1G10" +
            "gJuQZdcF2Luqm/hccMw==";
        public static string GenerateToken(string userName,
            int expireMinutes = 20)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.Now;
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName) }),
                Expires = now.AddSeconds(Convert.ToInt32(expireMinutes)),
                //- Expires{2020-07-07 00:05:04,
                NotBefore = now,
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };
            // JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(descriptor);
            var sToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(sToken);
            return token;
            }
        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    ValidAudience = "my Audience",
                    ValidIssuer = "myIssuer",
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    //LifetimeValidatoor=Cus
                    RequireExpirationTime = true,
                    //ValidateIssuer=false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                    parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
        public static string ValidateToken(string token)
        {
            string userName = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
            //{
            //}
            return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch(NullReferenceException)
            {
                return null;
            }
            Claim userNameClaim = identity.FindFirst(ClaimTypes.Name);
            userName = userNameClaim.Value;
            return userName;
        }
    }
}
