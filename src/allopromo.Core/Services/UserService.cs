using allopromo.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using allopromo.Core.Domain;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using allopromo.Core.Helpers;
using allopromo.Core.Entities.Identity;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using allopromo.Core.Entities;

namespace allopromo.Core.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private HttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration Configuration;
        public UserManager<ApplicationUser> _userManager { get; set; }
        public UserService(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          RoleManager<IdentityRole> roleManager,
          IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            Configuration = configuration;
        }

        public async Task<bool> CreateUser(string userName, string password)
        {
            bool userCreated = false;
            if (userName == null)
                throw new Exception();
            try
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Id = Guid.NewGuid().ToString();
                applicationUser.Email = userName;
                applicationUser.UserName = userName;
                ApplicationUser user = applicationUser;
                IdentityResult async = await this._roleManager.CreateAsync(new IdentityRole("Users"));
                if (this._userManager?.CreateAsync(user, password) != null)
                {
                    IdentityResult roleAsync = await this._userManager.AddToRoleAsync(user, "Users");
                    userCreated = true;
                }
                user = (ApplicationUser)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<bool>(userCreated);
        }

        public async Task<List<ApplicationUser>> GetUsersWithRolesAsync()
        {
            IList<ApplicationUser> applicationUserList = 
                (IList<ApplicationUser>)new List<ApplicationUser>();
            try
            {
                var listofUsers = await _userManager.Users.ToListAsync();

                // ISSUE: method reference
                // ISSUE: method reference

                /*this..Users
                    .AsQueryable<ApplicationUser>().Select<ApplicationUser, ApplicationUser>(Expression.Lambda<Func<ApplicationUser, ApplicationUser>>((Expression)Expression.MemberInit(Expression.New(typeof(ApplicationUser)), (MemberBinding)Expression.Bind((MethodInfo)MethodBase.GetMethodFromHandle(__methodref(IdentityUser<string>.set_UserName), __typeref(IdentityUser<string>)), )))); // Unable to render the statement
                ((IIncludableQueryable<ApplicationUser, IEnumerable<ApplicationRole>>)this._userManager.Users.Include<ApplicationUser, IList<ApplicationRole>>((Expression<Func<ApplicationUser, IList<ApplicationRole>>>)(u => u.UserRoles))).ThenInclude<ApplicationUser, ApplicationRole, string>((Expression<Func<ApplicationRole, string>>)(ur => ur.roleName));
                */

                return listofUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddUserRole(ApplicationUser user, string roleName)
        {
            this._userManager.AddToRoleAsync(user, roleName);
        }

        public void DeleteUser(ApplicationUser user) => throw new NotImplementedException();

        public async Task<IList<ApplicationUser>> GetUsersByRole(string roleName)
        {
            return await this._userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await this._userManager.FindByIdAsync(userId);
        }

        public async Task<bool> UpdateUserRole(string newRoleName, string userName)
        {
            if (newRoleName == null)
                throw new ArgumentNullException("roleName");
            if (userName == null)
                throw new ArgumentNullException("userName ");
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            string oldRoleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            var roleAsync = await _userManager.AddToRoleAsync(user, newRoleName);
            if (roleAsync.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                return true;
            }
            return false;   
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            string currentLogin = new HttpContextAccessor().HttpContext?.User.Claims.First<Claim>((Func<Claim, bool>)(x => x.Type == "id")).Value;
            return (await this._userManager.Users.AsQueryable<ApplicationUser>().ToListAsync<ApplicationUser>()).Where<ApplicationUser>((Func<ApplicationUser, bool>)(user => user.UserName.Equals(currentLogin))).FirstOrDefault<ApplicationUser>();
        }
        /*
        public async Task<string> GenerateJwtTokentt597(ApplicationUser user)
        {
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            byte[] bytes = Encoding.ASCII.GetBytes(new AppSettings()
            {
                Secret = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
            }.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
              Subject = new ClaimsIdentity((IEnumerable<Claim>)new Claim[1]
              {
                new Claim("id", user.UserName.ToString())
              }),
                Expires = new DateTime?(DateTime.UtcNow.AddDays(7.0)),
                SigningCredentials = new SigningCredentials((SecurityKey)new SymmetricSecurityKey(bytes), "HS256")
            };
            SecurityToken token = securityTokenHandler.CreateToken(tokenDescriptor);
            return securityTokenHandler.WriteToken(token);
        }
        */
        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Configuration["Jwt:Secret"]);
            IList<string> rolesAsync = await this._userManager.GetRolesAsync(user);
            string jwtToken = tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = Configuration["Jwt:ValidIssuer"],
                Audience = Configuration["Jwt:ValidAudience"],
                Subject = new ClaimsIdentity((IEnumerable<Claim>)new Claim[2]
              {
          new Claim("id", user.UserName.ToString()),
          new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", rolesAsync.FirstOrDefault<string>())
              }),
                Expires = new DateTime?(DateTime.UtcNow.AddHours(2.0)),
                SigningCredentials = new SigningCredentials((SecurityKey)new SymmetricSecurityKey(key), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")
            }));
            tokenHandler = (JwtSecurityTokenHandler)null;
            key = (byte[])null;
            return jwtToken;
        }

        public async Task<string> GenerateJwtToken123(allopromo.Core.Entities.ApplicationUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Configuration["Jwt:Secret"]);
            Encoding.ASCII.GetBytes(new AppSettings()
            {
                Secret = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
            }.Secret);
            List<Claim> claims = new List<Claim>()
      {
        new Claim("aud", "https://localhost:44306"),
        new Claim("iss", "http://www.allo.promo"),
        new Claim("email", user.Email ?? ""),
        new Claim("name", user.firstName?? ""),
        new Claim("nameid", user.Id ?? "")
      };
            foreach (string str in (IEnumerable<string>)await this._userManager.GetRolesAsync(user))
                claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", str));
            string jwtToken123 = tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = Configuration["Jwt:ValidIssuer"],
                Audience = Configuration["Jwt:ValidAudience"],
                Expires = new DateTime?(DateTime.UtcNow.AddDays(1.0)),
                Subject = new ClaimsIdentity((IEnumerable<Claim>)new Claim[1]
              {
          new Claim("id", user.UserName.ToString())
              }),
                SigningCredentials = new SigningCredentials((SecurityKey)new SymmetricSecurityKey(key), "HS256")
            }));
            tokenHandler = (JwtSecurityTokenHandler)null;
            key = (byte[])null;
            claims = (List<Claim>)null;
            return jwtToken123;
        }

        public string GenerateJwtToken456(string email, string role)
        {
            string str1 = Configuration["Jwt:Issuer"];
            string str2 = Configuration["Jwt:Audience"];
            byte[] bytes = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity((IEnumerable<Claim>)new Claim[5]
              {
          new Claim("Id", Guid.NewGuid().ToString()),
          new Claim("sub", email),
          new Claim(nameof (email), email),
          new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role),
          new Claim("jti", Guid.NewGuid().ToString())
              }),
                Expires = new DateTime?(DateTime.UtcNow.AddMinutes(5.0)),
                Issuer = str1,
                Audience = str2,
                SigningCredentials = new SigningCredentials((SecurityKey)new SymmetricSecurityKey(bytes), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha512")
            };
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            return securityTokenHandler.WriteToken(securityTokenHandler.CreateToken(tokenDescriptor));
        }

        private IList<IdentityRole> getUserRoles(ApplicationUser user)
        {
            IList<IdentityRole> userRoles = (IList<IdentityRole>)new List<IdentityRole>();
            if (user == null)
                throw new Exception("user NUll");
            foreach (string str in (IEnumerable<string>)this._userManager.GetRolesAsync(user).Result)
            {
                IList<IdentityRole> identityRoleList = userRoles;
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = str;
                identityRoleList.Add(identityRole);
            }
            return userRoles;
        }
    }

    /*
    public class UserService12 : IUserService                                                             
   {
#region Properties
        public UserManager<IdentityUser> _userManager { get; set; }
        private readonly SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        //private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        private HttpContextAccessor _httpContextAccessor;

        //private AppSettings _appSettings;
#endregion

#region Constructors
        public UserService12 (
            UserManager<IdentityUser> userManager, 
                            SignInManager<IdentityUser> signInManager,
                            RoleManager<IdentityRole> roleManager

                            //AppSettings appSettings
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            //_appSettings = appSettings;
        }
        //public UserService()
        //{}
#endregion

#region Public Methods - Getting

        //Constructor - base Methods - Constantes - Pptes - CRUD methods - Specific Method - Validation 
        public async Task<List<Entities.Identity.tUser>> GetUsersAsync()
        {
            IList<tUser> users = new List<tUser>();
            try
            {
                var usersObj = await _userManager.Users.ToListAsync();
                var role = GetRoleNameByUser(usersObj.FirstOrDefault());
                foreach (var userObj in usersObj)
                {
                    users.Add(new tUser
                    {
                         UserName=userObj.UserName,
                         Email=userObj.Email,
                         PhoneNumber=userObj.PhoneNumber,
                         //AspNetUserRoles=role
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users.ToList();
        }
        public IQueryable<IdentityRole> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return roles;
        }
        private string GetRoleNameByUser(IdentityUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles != null)
            {
                return roles.FirstOrDefault();
            }
            return string.Empty;
        }
        public string GetUserRole(IdentityUser user)
        {
            return GetRoleNameByUser(user);
        }
        private async Task<List<IdentityRole>> GetRoles() => await _roleManager.Roles.ToListAsync();
        private async Task<bool> UserExists(string userName)
        {
            bool userExists = false;
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                    userExists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userExists;
        }
        public bool LoginUser(IdentityUser user)
        {
            try
            {
                var login = _signInManager.SignInAsync(user, true, null);
                if (login != null)
                   return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ApplicationUser AuthenticateUser(string UserName, string PasswordHash)
        {
            // var user = _userRepo.GetUsers().FirstOrDefault(x => x.UserName == userName 
            // && x.PasswordHash == password);
            object user = null;
            if (user != null)
            {
                //var  _appSettings = new AppSettings();

                var tokenHandler = new JwtSecurityTokenHandler();

                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFsaXdpeWFvQGdtYWlsLmNvbSIsIm5iZiI6MTYzMTY1MDQxMCwiZXhwIjoxNjMxNjUwNDMwLCJpYXQiOjE2MzE2NTA0MTF9.9oLqiHV66WvxkEJTq3lZWaEqBW1a5CkNZLtbTz53IBA");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //new Claim(ClaimTypes.Name, user.Id.ToString()) 
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //user.userToken = tokenHandler.WriteToken(token);
                //user.PasswordHash = null;
               // return user;
            }
            return null;
        }
#endregion

#region Public Methods - Create
        public async Task<bool> CreateUser(string userName, string password)
        {
            bool userCreated = false;
            if (userName != null)
            {
                try
                {
                    IdentityUser user = new IdentityUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = userName,
                        UserName = userName,
                    };
                    var identityRole = new IdentityRole("Users");
                    var role = await _roleManager.CreateAsync(identityRole);
                    var appUser = _userManager?.CreateAsync(user, password);
                    if (appUser != null)                 //&& result.Succeenrd((bool)(result?.Succeeded))
                    {
                        await _userManager.AddToRoleAsync(user, "Users");
                        userCreated = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception();
            return await Task.FromResult(userCreated);
        }
        #endregion
        #region Public Methods - Validation
       
        private void AddUserRole(ApplicationUser user, string roleName)
        {
            _userManager.AddToRoleAsync(user, roleName);
        }
        public void DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<IList<IdentityUser>> GetUsersByRole(string roleName) 
            => await _userManager.GetUsersInRoleAsync(roleName);

        public async Task<IdentityUser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user; // as tUser;
        }
        #endregion

#region Public Methods - Others Methods
        public ApplicationUser GetUserRole(ApplicationUser appUser)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName.Equals(appUser.UserName));

            //.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            //.Where(x => x.UserName == appUser.UserName)
            //.FirstOrDefault());
            /*var user11= _userManager.Users.Select(x=>x.UserName.Equals(appUser.UserName))
                .Join(_roleManager.Roles)
            var query23 = (from u in _userManager.Users
                           join r in _roleManager.Roles on u.Us equals r.Name);
                            //where u.Email=="alistcom" select u);
            var users32= _userManager.Users;
            var roles = _roleManager.Roles;
            users32.Include(u => u.UserRoles).ThenInclude(ur=>ur.Role);*/
            /*return null;
        }
        public ClaimsPrincipal GetCurrentUser()
        {
            _httpContextAccessor = new HttpContextAccessor();
            var user = _httpContextAccessor.HttpContext?.User;

            //return User.Identity.Name.ToString();

            return user;
            
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ApplicationUser user = await _userManager.FindByNameAsync(currentUserName);

            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        }
        public IList<IdentityUser> GetUsersInRole(string roleName)
        {
            var users = GetUsersByRole(roleName);
            return users.Result;
        }
        public void UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public ApplicationUser GetUserByNameOrEmail(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        //public UserDto GetUserById(string userId)
        //{
        //    var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(userId));
        //    return null;

        //    //return AutoMapper.Mapper.Map<ApplicationUser, UserDto>(user); // Manager.Users.FirstOrDefault(x => x.Id.Equals(userId));
        //}
        Task<string> IUserService.GetUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        void IUserService.DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        void IUserService.UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        IList<ApplicationUser> IUserService.GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        ApplicationUser IUserService.GetUserRole(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public string GenerateJwtToken(IdentityUser user)
        {
            // generate token that is valid for 7 days

            var tokenHandler = new JwtSecurityTokenHandler();
            AppSettings apSettings = new AppSettings
            {
                Secret = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
            };
            var key = Encoding.ASCII.GetBytes(apSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }*/
}





// BuySellAds ?
//Code Coverage ? Input Possibilities | User is Valid , 
//password is Invalid - user is Valid, passwd is Valid -

/*Factory Method DEsign Pattern vs Builder Pattern ?  --- Abstract Factory | Factory |
Factory Pattern::
Product						Creator[factoryMethod()]
.							.
.							.
Concrete		<----		ConcreteCreator[factoryMethod()]

Product: interface of the being Created Classes

(3) types of Card to Create:
-Credit - Patinum - MoneyBack ( all being concrete of abstract Card)
-Factory are : CardFactory - from wichi derive 3 types of services for these (3) type ofCard


Credit: cardType - creditLimimt - annualCharge---
MoneyBack: public MoneyBack(){_creditimit=creditLim, _an=anual, _cartYpe="Moeny Back"}...

//_logger.Information(ex.Message); 
//throw new ArgumentNullException("{Valeur ne peut etre nulle");

in Client:
CardFactory cardFactory =null;
 case:MoneyBack , factory= new MoneybackCard(), case:.....
###########################################################
*/