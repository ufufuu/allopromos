
using allopromo.Api.DTOs;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly
#nullable disable
    IUserService _userService;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPermissionService _permissionService;

        private ILogger logger { get; set; }

        public AccountController(
          IUserService userService,
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager,
          IMapper mapper)
        {
            this._userService = userService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._mapper = mapper;
        }

        [ActivatorUtilitiesConstructor]
        public AccountController(
          IUserService userService,
          IMembershipService accountService,
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<AccountController> logger,
          IMapper Mapper)
        {
            this._userService = userService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._mapper = Mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers()
        {
            AccountController accountController = this;
            List<ApplicationUser> usersWithRolesAsync = await accountController._userService.GetUsersWithRolesAsync();
            List<UserDto> userDtoList = accountController._mapper.Map<List<UserDto>>((object)usersWithRolesAsync);
            return (IActionResult)accountController.Ok((object)userDtoList);
        }

        [HttpPost]
        [Route("password-recovery")]
        [AllowAnonymous]
        public async Task<IActionResult> PasswordRecovery(string telephoneNumber, string userName)
        {
            AccountController accountController = this;
            if (telephoneNumber != null)
            {
                ApplicationUser byNameAsync = await accountController._userManager.FindByNameAsync(userName);
                if (byNameAsync == null)
                    return (IActionResult)accountController.BadRequest();
                int num = byNameAsync.PhoneNumber == telephoneNumber ? 1 : 0;
            }
            return (IActionResult)accountController.NotFound();
        }

        [HttpPut]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UpdateUserDto udpateUserDto)
        {
            AccountController accountController = this;
            List<ApplicationUser> usersWithRolesAsync = await accountController._userService.GetUsersWithRolesAsync();
            List<UserDto> userDtoList = accountController._mapper.Map<List<UserDto>>((object)usersWithRolesAsync);
            return (IActionResult)accountController.Ok((object)userDtoList);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            AccountController accountController = this;
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                return (IActionResult)accountController.BadRequest(accountController.ModelState);
            if (await accountController._userManager.FindByEmailAsync(dto.UserName) != null)
                return (IActionResult)accountController.StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "User Already Exist!"
                });
            if (!accountController.ModelState.IsValid)
                return (IActionResult)accountController.BadRequest();
            ApplicationUser user = accountController._mapper.Map<ApplicationUser>((object)dto);
            if ((await accountController._userManager.CreateAsync(user, dto.Password)).Succeeded)
            {
                accountController._roleManager.Roles.Where<IdentityRole>((Expression<Func<IdentityRole, bool>>)(x => x.Name == dto.roleName));
                IdentityResult roleAsync = await accountController._userManager.AddToRoleAsync(user, dto.roleName);
                allopromo.Api.Model.Response response1 = new allopromo.Api.Model.Response();
                response1.Status = "Success";
                response1.Message = "User Created Successfully!";
                allopromo.Api.Model.Response response2 = response1;
                response2.jwtToken = await accountController._userService.GenerateJwtToken(user);
                return (IActionResult)accountController.Ok((object)response1);
            }
            return (IActionResult)accountController.StatusCode(500, (object)new allopromo.Api.Model.Response()
            {
                Status = "Error",
                Message = "User Creation Failed, Check user Details"
            });
        }

        [Route("Logout")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Logout()
        {
            AccountController accountController = this;
            await accountController._signInManager.SignOutAsync();
            accountController.HttpContext.Session.Clear();
            return (IActionResult)accountController.Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            AccountController accountController = this;
            if (dto == null)
                throw new Exception();
            ApplicationUser user = await accountController._userManager.FindByEmailAsync(dto.UserName);
            if (user == null)
                return (IActionResult)accountController.Unauthorized();
            if (!accountController._signInManager.UserManager.CheckPasswordAsync(user, dto.Password).Result)
                return (IActionResult)accountController.NotFound((object)new
                {
                    status = " Failed ",
                    message = " User name or Pwd UUY incorrect "
                });
            SignInManager<ApplicationUser> signInManager = accountController._signInManager;
            ApplicationUser user1 = new ApplicationUser();
            user1.UserName = dto.UserName;
            await signInManager.SignInAsync(user1, true);
            UserDto userDto = accountController._mapper.Map<UserDto>((object)user);
            string jwtToken = await accountController._userService.GenerateJwtToken(user);
            return (IActionResult)accountController.Ok((object)new
            {
                user = userDto,
                jwtToken = jwtToken
            });
        }

        [Route("register-admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] CreateUserDto dto)
        {
            AccountController accountController = this;
            if (await accountController._userManager.FindByNameAsync(dto.UserName) != null)
                return (IActionResult)accountController.StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "user Already Exists"
                });
            ApplicationUser user = accountController._mapper.Map<ApplicationUser>((object)dto.UserName);
            if (!(await accountController._userManager.CreateAsync(user, dto.Password)).Succeeded)
                return (IActionResult)accountController.StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "User already Exist"
                });
            if (await accountController._roleManager.RoleExistsAsync(dto.roleName))
            {
                IdentityRole byIdAsync = await accountController._roleManager.FindByIdAsync("");
                IdentityResult roleAsync = await accountController._userManager.AddToRoleAsync(user, byIdAsync.Name);
            }
            return (IActionResult)accountController.Ok((object)new allopromo.Api.Model.Response()
            {
                Status = "Success",
                Message = "Admin User Created Successfully!"
            });
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("current-user")]
        public async Task<IActionResult> GetCurrentUserName()
        {
            AccountController accountController = this;
            ApplicationUser currentUser = await accountController._userService.GetCurrentUser();
            ApplicationUser byNameAsync = await accountController._userManager.FindByNameAsync(currentUser.UserName);
            UserDto userDto = accountController._mapper.Map<UserDto>((object)byNameAsync);
            return (IActionResult)accountController.Ok((object)userDto);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUser(string Id, [FromBody] UserDto updateUserDto)
        {
            AccountController accountController = this;
            if (await accountController._userManager.FindByEmailAsync(updateUserDto.UserName) == null)
                return (IActionResult)accountController.NotFound((object)"User Not Found");
            ApplicationUser byNameAsync = await accountController._userManager.FindByNameAsync(updateUserDto.UserName);
            byNameAsync.UserName = updateUserDto.UserName;
            byNameAsync.Email = updateUserDto.Email;
            byNameAsync.PhoneNumber = updateUserDto.PhoneNumber;
            UserDto userDto = accountController._mapper.Map<UserDto>((object)byNameAsync);
            return (IActionResult)accountController.Ok((object)userDto);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("detele-user/{id}")]
        public async Task<IActionResult> DeleteCurrenUser(UserDto model)
        {
            AccountController accountController = this;
            ApplicationUser currentUser = await accountController._userService.GetCurrentUser();
            ApplicationUser byNameAsync = await accountController._userManager.FindByNameAsync(currentUser.UserName);
            UserDto userDto = accountController._mapper.Map<UserDto>((object)byNameAsync);
            return (IActionResult)accountController.Ok((object)userDto);
        }

        [HttpPost]
        [Route("{adressId}")]
        public async Task<IActionResult> AddAdress() => (IActionResult)this.Ok();

        [HttpDelete]
        [Route("{adressId}")]
        public async Task<IActionResult> AdressDelete() => (IActionResult)this.Ok();

        [HttpPut]
        [Route("{adressId}")]
        public async Task<IActionResult> AdressEdit() => (IActionResult)this.Ok();

        [HttpPatch]
        public async Task<IActionResult> ConfirmCurrentLocalization() => (IActionResult)this.Ok();

        [HttpGet]
        [Route("CheckUserName")]
        public async Task<IActionResult> CheckUserAvailability()
        {
            AccountController accountController = this;
            List<ApplicationUser> usersWithRolesAsync = await accountController._userService.GetUsersWithRolesAsync();
            List<UserDto> userDtoList = accountController._mapper.Map<List<UserDto>>((object)usersWithRolesAsync);
            return (IActionResult)accountController.Ok((object)userDtoList);
        }
    }
}
