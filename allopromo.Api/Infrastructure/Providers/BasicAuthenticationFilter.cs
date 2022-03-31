using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
//using System.Web.Http.Filters;
//using System.Web.Http.Filters;
//using IAuthenticationFilter=System.Web.
namespace allopromo.Infrastructure.Providers
{
    //public class BasicAuthenticationFilter:AuthorizationFilterAttribute

    public class BasicAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public  void OnAuthorization(AuthorizationFilterContext actionContext)
        {
            if (actionContext.Result.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.
                    Authorization.Parameter;
                string decodedAuthorizationToken = Encoding
                    .UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthorizationToken.Split(':');
                string userName = userNamePasswordArray[0];
                string password = userNamePasswordArray[1];
                var accountRep = new AccountRepository();
                //if (AccountRepository.UserIsValid(userName, password))
                //{
                    Thread.CurrentPrincipal =
                        new GenericPrincipal(new GenericIdentity(username), null);
                //}
                //else
                //{
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
        }
    }
}
/*
  options:
  - vendre le vehicule !
  <--- $ 12.761 ---> 
  }*/
/*
 * securing Web Api
 * 1 - in Startup : servies.AddMvc(options =>{options.Filters.Add(new AuthorizeFilter(new AuthorizationPokicyBuilde(
 * .RequireAuthenticatedUSer().Build())));
 * 2. in COnfig , Enable Authentication: app.UseAuthentication();
 * 3. in CONfigureService Method: add authentication
 * services.AddAuthentication(options =>{options.DefaultAUthenticaScheme=
 * CUstomAuthOptions.DEfaultScheme;
 * options.DEfaultChallengeScheme=CustomAuthOptions