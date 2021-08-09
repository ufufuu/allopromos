using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http.Filters;
namespace allopromo.allopromo.Infrastructure.Providers
{
   public class BasicAuthenticationFilter//:AuthorizationFilterAttribute
    {/*
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response=actionContext.Request
                    //CreateResponse(HttpStatusCode.Unauthorized)
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
                if(AccountRepository.UserIsValid(userName, password))
                {
                    Thread.CurrentPrincipal =
                        new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

        options:

        - vendre le vehicule !
        <--- $ 12.761 --->
        - 
        -
        - 
        }*/
    }
}
