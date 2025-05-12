
using allopromo.Api.DTOs;
using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //private ILogger logger { get; set; }

        public AccountController(
          IUserService userService,
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager,
          IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [ActivatorUtilitiesConstructor]
        public AccountController(
          IUserService userService,
          
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<AccountController> logger,
          IMapper Mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = Mapper;
        }
        [HttpGet]

        //[Route("")]
        public async Task<IActionResult> GetUsers()
        {
			var users = new List<UserDto>();
            var usersObj = await _userService.GetUsersWithRolesAsync();
			
            List<ApplicationUser> usersWithRolesAsync = await _userService.GetUsersWithRolesAsync();
            users = _mapper.Map<List<UserDto>>(usersObj);
            return Ok(users);
        }
        [HttpPost]
        //[Route("password-recovery")]
        //[AllowAnonymous]
		
        public async Task<IActionResult> PasswordRecovery(string telephoneNumber, string userName)
        {
            if (telephoneNumber != null)
            {
                ApplicationUser byNameAsync = await _userManager.FindByNameAsync(userName);
                if (byNameAsync == null)
                    return BadRequest();
                int num = byNameAsync.PhoneNumber == telephoneNumber ? 1 : 0;
            }
            return NotFound();
        }

        [HttpPut]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UpdateUserDto udpateUserDto)
        {
            List<ApplicationUser> usersWithRolesAsync = await _userService.GetUsersWithRolesAsync();
            List<UserDto> userDtoList = _mapper.Map<List<UserDto>>((object)usersWithRolesAsync);
            return Ok(userDtoList);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                return BadRequest(ModelState);

            if (await _userManager.FindByEmailAsync(dto.UserName) != null)
                return StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "User Already Exist!"
                });
            if (ModelState.IsValid)
                return BadRequest();
            ApplicationUser user = _mapper.Map<ApplicationUser>(dto);
            if ((await _userManager.CreateAsync(user, dto.Password)).Succeeded)
            {
                _roleManager.Roles.Where<IdentityRole>((Expression<Func<IdentityRole, bool>>)(x => x.Name == dto.roleName));
                IdentityResult roleAsync = await _userManager.AddToRoleAsync(user, dto.roleName);
                allopromo.Api.Model.Response response1 = new allopromo.Api.Model.Response();
                response1.Status = "Success";
                response1.Message = "User Created Successfully!";
                allopromo.Api.Model.Response response2 = response1;
                response2.jwtToken = await _userService.GenerateJwtToken(user);
                return Ok(response1);
            }
            return StatusCode(500, (object)new allopromo.Api.Model.Response()
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
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            if (dto == null)
                return BadRequest();
            ApplicationUser user = await _userManager.FindByEmailAsync(dto.UserName);
            if (user == null)
                return Unauthorized();
            if (!_signInManager.UserManager.CheckPasswordAsync(user, dto.Password).Result)
                return NotFound(new
             {
                status = " Failed ",
                message = " User name or Pwd UUY incorrect "
             });
            //var signedIn = await _signInManager.SignInAsync(user, true);

            UserDto userDto = _mapper.Map<UserDto>(user);
            string jwtToken = await _userService.GenerateJwtToken(user);
            var userRole = await _userManager.GetRolesAsync(user);
            return Ok(new
            {
                user = userDto,
                jwtToken = jwtToken,
                role = userRole.FirstOrDefault().ToString(),
            });
        }
        [Route("register-admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] CreateUserDto dto)
        {
            
            if (await _userManager.FindByNameAsync(dto.UserName) != null)
                return StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "user Already Exists"
                });
            ApplicationUser user = _mapper.Map<ApplicationUser>((object)dto.UserName);
            if (!(await _userManager.CreateAsync(user, dto.Password)).Succeeded)
                return StatusCode(500, (object)new allopromo.Api.Model.Response()
                {
                    Status = "Error",
                    Message = "User already Exist"
                });
            if (await _roleManager.RoleExistsAsync(dto.roleName))
            {
                IdentityRole byIdAsync = await _roleManager.FindByIdAsync("");
                IdentityResult roleAsync = await _userManager.AddToRoleAsync(user, byIdAsync.Name);
            }
            return Ok(new allopromo.Api.Model.Response()
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
            ApplicationUser currentUser = await _userService.GetCurrentUser();
            ApplicationUser byNameAsync = await _userManager.FindByNameAsync(currentUser.UserName);
            UserDto userDto = _mapper.Map<UserDto>((object)byNameAsync);
            return Ok(userDto);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUser(string Id, [FromBody] UserDto updateUserDto)
        {
            if (await _userManager.FindByEmailAsync(updateUserDto.UserName) == null)
                return NotFound("User Not Found");
            ApplicationUser byNameAsync = await _userManager.FindByNameAsync(updateUserDto.UserName);
            byNameAsync.UserName = updateUserDto.UserName;
            byNameAsync.Email = updateUserDto.Email;
            byNameAsync.PhoneNumber = updateUserDto.PhoneNumber;
            UserDto userDto = _mapper.Map<UserDto>((object)byNameAsync);
            return Ok(userDto);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("detele-user/{id}")]
        public async Task<IActionResult> DeleteCurrenUser(UserDto model)
        {
            ApplicationUser currentUser = await _userService.GetCurrentUser();
            ApplicationUser byNameAsync = await _userManager.FindByNameAsync(currentUser.UserName);
            UserDto userDto = _mapper.Map<UserDto>((object)byNameAsync);
            return Ok(userDto);
        }

        [HttpPost]
        [Route("{adressId}")]
        public IActionResult AddAdress()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{adressId}")]
        public IActionResult AdressDelete()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{adressId}")]
        public IActionResult AdressEdit()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult ConfirmCurrentLocalization()
        {
            return Ok();
        }

        [HttpGet]
        [Route("CheckUserName")]
        public async Task<IActionResult> CheckUserAvailability()
        {
            List<ApplicationUser> usersWithRolesAsync = await _userService.GetUsersWithRolesAsync();
            List<UserDto> userDtoList = _mapper.Map<List<UserDto>>(usersWithRolesAsync);
            return Ok(userDtoList);
        }
    }
}