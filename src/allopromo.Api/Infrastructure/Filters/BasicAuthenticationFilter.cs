using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Http.Filters;
namespace allopromo.Api.Infrastructure.Filters
{
    public abstract class BasicAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        //public bool AllowMultiple => throw new NotImplementedException();
        public virtual bool AllowMultiple
        {
            get { return false; }
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if((authorization == null)||(authorization.Scheme!="basic")||(String.IsNullOrEmpty(authorization.Parameter)))
            {
                return ; // why async return JUST not return null ?
            }
            Tuple<string, string> userNameAndPassword = ExtractUserNameAndPassword(authorization.Parameter);
            if (userNameAndPassword == null)
            {
                //context.ErrorResult = new AuthenticationFailureResult("Invalid Credentials", request);
                return ;
            }
            string userName = userNameAndPassword.Item1;
            string password = userNameAndPassword.Item2;
            IPrincipal principal = await AuthenticateAsync(userName, password, cancellationToken);
            if (principal == null)
            {
                //context.ErrorResult = new AuthenticationFailureResult("Invalid Username or Password");
            }
            else
            {
                context.Principal = principal;
            }
            //return Task.FromResult(0);
        }
        protected abstract Task<IPrincipal> AuthenticateAsync(string userName, string password,
            CancellationToken cancellationToken);

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }
        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter;
            if (String.IsNullOrEmpty(Realm))
            {
                parameter = null;
            }
            else
            {
                parameter = "realm=\"" + Realm + "\"";
            }
           // context.ChallengeWith("Basic", parameter);
        }
        private Tuple<string, string> ExtractUserNameAndPassword(string authorizationParameter)
        {
            byte[] credentialsByte;
            try
            {
                credentialsByte = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return null;
            }
            Encoding encoding = Encoding.ASCII;
            encoding = (Encoding)encoding.Clone();
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            string decodedCredentials;
            try 
            { 
                decodedCredentials = encoding.GetString(credentialsByte);
            }
            catch (DecoderFallbackException)
            {
                return null;
            }
            if (String.IsNullOrEmpty(decodedCredentials))
                return null;
            int colonIndex = decodedCredentials.IndexOf(':');
            if (colonIndex == -1)
                return null;
            string userName = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);
            return new Tuple<string, string>(userName, password);
        }
    }
}
