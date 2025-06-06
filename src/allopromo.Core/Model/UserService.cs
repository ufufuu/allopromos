﻿using allopromo.Core.Abstract;
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
using allopromo.Core.Helpers;
namespace allopromo.Core.Model
{
   public class UserService : IUserService                                                             
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
        public UserService(
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
        public async Task<List<UserDto>> GetUsersAsync()
        {
            IList<UserDto> users = new List<UserDto>();
            try
            {
                var usersObj = await _userManager.Users.ToListAsync();
                var role = GetRoleNameByUser(usersObj.FirstOrDefault());
                foreach (var userObj in usersObj)
                {
                    users.Add(new UserDto
                    {
                        userName=userObj.UserName,
                        userEmail=userObj.Email,
                        userPhoneNumber=userObj.PhoneNumber,
                        userRoleName=role
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
                throw;
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

        public async Task<UserDto> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId); 
            return AutoMapper.Mapper.Map<IdentityUser, UserDto>(user);
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
            return null;
        }
        public ClaimsPrincipal GetCurrentUser()
        {
            _httpContextAccessor = new HttpContextAccessor();
            var user = _httpContextAccessor.HttpContext?.User;

            //return User.Identity.Name.ToString();

            var gt = 56;
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

//_logger.Information(ex.Message); 
//throw new ArgumentNullException("{Valeur ne peut etre nulle");

in Client:
CardFactory cardFactory =null;
 case:MoneyBack , factory= new MoneybackCard(), case:.....
###########################################################
*/