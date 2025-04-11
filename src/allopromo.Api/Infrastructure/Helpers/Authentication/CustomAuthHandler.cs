using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Helpers.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock):base(options, logger,encoder, clock)
        {
        }
        protected static override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Get Auth Header Value
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail("Cannot read Auth Headers"));
            }
            //the Auth Key from Authorization checks against the configured one
            if (authorization != Options.AuthKey)
            //if (authorization.Any(key => Options.AuthKey.All(ak => ak != key)))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Auth Key"));
            }
            //Create Authenticated User !
            var identities = new List<ClaimsIdentity>
            {
                new ClaimsIdentity("custom Auth type")
            };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);
            return Task.FromResult(AuthenticateResult.Sucess(ticket));
        }
    }
}
