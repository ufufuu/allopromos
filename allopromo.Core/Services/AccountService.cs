using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Helpers;
using allopromo.Core.Model.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Model
{
    public class AccountService:IAccountService
    {
        public delegate void UserAuthenticatedEventHandler(object source, EventArgs e);

        public event UserAuthenticatedEventHandler userAuthenticated;
        private static UserManager<ApplicationUser> _userManager { get; set; }

        private readonly AppSettings _appSettings;
        private HttpContextAccessor _httpContextAccessor;

        //public event EventHandler<UserAuthenticateEventArgs> OnUserAuthenticated;
        public AccountService()
        {
        }
        public AccountService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public void OnUserAuthenticate(string userName)
        {
            //....
            OnUserAuthenticated();  //userAuthenticated(new object(), new EventArgs());
        }
        protected virtual void OnUserAuthenticated()
        {
            if (userAuthenticated != null)
            {
                userAuthenticated(this, EventArgs.Empty);
            }
        }
        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
        public LoginResponseModel Authenticate(ApplicationUser loginModel)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName
                        == loginModel.UserName);  //&& x.PasswordHash == loginModel.userPassword);
            if (user == null) return null;

            // authentication successful so generate jwt token
            OnUserAuthenticated();

            var token = generateJwtToken(user);
            //return new AuthenticateResponse(user, token);
            return new LoginResponseModel(user, token);
        }
        public string generateJwtToken(IdentityUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task CreatesAccount(ApplicationUser user, string userpwd)
        {
            await new Task(null);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public LoginResponseModel Authenticate(string userName)
        {
            throw new NotImplementedException();
        }

        void IAccountService.OnUserAuthenticated()
        {
            throw new NotImplementedException();
        }
        public string GetCurrentName()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;

            //System.Security.Claims.ClaimsPrincipal currentUtils = this.User;
            //ClaimsPrincipal currentUser = this.User;

            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var claimss = currentUser.Claims.FirstOrDefault();
            //ApplicationUser user = await _userManager.FindByNameAsync(currentUserName);

            bool isAdmin = currentUser.IsInRole("Admin");

            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            IdentityUser utlisateur = _userManager.FindByNameAsync(currentUserName).Result;
            
            /*var nameIdentifier = User
                .Claims
                .FirstOrDefault(c => c.Type == System.Security.Claims
                .ClaimTypes
                .NameIdentifier)?.Value;*/
            //var curUser = nameIdentifier.ToString();

            return currentUser.Identity.Name.ToString();
        }
    }
}
