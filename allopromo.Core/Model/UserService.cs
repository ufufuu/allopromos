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
using allopromo.Core.Application.Dto;

namespace allopromo.Core.Model
{
   public class UserService : IUserService 
   {
        private readonly IUserRepository _userRepo;

        private readonly UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>(); 
        private readonly SignInManager<ApplicationUser> _signInManager;

        //private Serilog.ILogger _logger;           // vs Microsoft Logging !

        private HttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepo, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public ApplicationUser GetUserIfExist(string userName)
        {
            var user = this._userManager.FindByNameAsync(userName);
            return user.Result;
        }
        private async Task<bool> UserExists(string userName)
        {
            bool userExists = false;
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                    userExists = true;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return userExists;
        }
        public bool LoginUser(ApplicationUser user)
        {
            try
            {
                   var login =  _signInManager.SignInAsync(user, true, null);
                    if (login != null)
                        return true;
                    return false;
            }
            //catch(SqlException ex)
            // {
            //   throw ex;
            //}
            catch(InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return false;
        }
        public ApplicationUser AuthenticateUser(string UserName, string PasswordHash)
        {
            // var user = _userRepo.GetUsers().FirstOrDefault(x => x.UserName == userName 
            //       && x.PasswordHash == password);
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
        public async Task<bool> CreateUser(ApplicationUser user, string password)
        {
            bool created = false;
            try
            {
                if (user == null)
                    return false;
                user.Id = Guid.NewGuid().ToString();
                var result = await _userManager?.CreateAsync(user, password);
                if(result!=null)// && result.Succeeded((bool)(result?.Succeeded))
                {
                    //AddUserRole(user, "Users");
                    created = true;
                    //var werwe = _signInManager;

                    //await _signInManager?.SignInAsync(user, isPersistent: false);

                    //var bgbg = await _signInManager?.SignInAsync(user, isPersistent: false);

                    //await _userManager.AddToRoleAsync(user, "SU");
                }
            }
            
            //catch (InvalidOperationException)
            //{
            //    throw new Exception("Operations Non Valide !");
            //}
            //catch (ArgumentNullException ex)
            //{
                
            //    _logger.Information(ex.Message); //throw new ArgumentNullException("{Valeur ne peut etre nulle");
            //    return default;
            //}
            
            catch (Exception ex)
            {
                //throw new Exception(" Une erreur est survenur. Veuillez re(essayer)");
                //return default;
                throw ex;
            }
            return created;
        }
        public bool ValidateUser(string userEmail, string userPassword)
        {
            var user = _userManager.FindByEmailAsync(userEmail);
            return _signInManager.UserManager.CheckPasswordAsync(user.Result, userPassword).Result;
        }
        private void AddUserRole(ApplicationUser user, string roleName)
        {
            _userManager.AddToRoleAsync(user, roleName);
        }
        public void DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public Task<IList<ApplicationUser>> GetUsersByRole(string roleName) =>
         _userManager.GetUsersInRoleAsync(roleName);

        public Task<string> GetUser(ApplicationUser user)
        {
            return _userManager.GetUserNameAsync(user);
        }
        public UserDto GetUserById(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            return AutoMapper.Mapper.Map<ApplicationUser, UserDto>(user);

        }
        public ApplicationUser GetUserRole(ApplicationUser appUser) // vs ApplicationUser user ?=>
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

            return null;

            //var query= (from _userManager.Users
            //var query9 = "SELECT from UserTable join [dbo].[AspNetUSerRoles] join [dbo.].[AspNetUsers]";
            //var YYUU= 
        }
        public ClaimsPrincipal GetCurrentUser()
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            _httpContextAccessor = new HttpContextAccessor();
            var user = _httpContextAccessor.HttpContext?.User;
            return user;
            /*
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.FindByNameAsync(currentUserName);*/
        }
        public List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> users = null;
            try
            {
                //users = UserConvertor.ConvertUsers(_userManager.Users
                ////.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                //.ToList());

                users = _userRepo.getUsers();
                //using(var db = new allopromo.Infrastructure.
                //{
                //}
                int j = 5;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return users;
        }
        public IList<ApplicationUser> GetUsersInRole(string roleName)
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
        public UserDto GetUserbyId(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(userId));
            return AutoMapper.Mapper.Map<ApplicationUser, UserDto>(user); // Manager.Users.FirstOrDefault(x => x.Id.Equals(userId));
        }
   }
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

in Client:
CardFactory cardFactory =null;
 case:MoneyBack , factory= new MoneybackCard(), case:.....
###########################################################
*/