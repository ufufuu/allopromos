using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string roleName { get; set; }

        public IList<RoleDto> UserRoles { get; set; }
    }
    public class UserDto45
    {
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPhoneNumber { get; set; }
        public string userRoleName { get; set; }
        public string userPassword { get; set; }



        //public List<RoleDto> Roles { get; set; }
        //public string UserRoles { get; set; }
        //public UserDto45()
        //{}
    }

    //public class UserConvertor
    //{
    //    public UserDto ConvertToDto(ApplicationUser appUser)
    //    {
    //        UserDto userDto = null;
    //        userDto.userName = appUser.UserName;
    //        userDto.userEmail = appUser.Email;
    //        return userDto;
    //    }
    //}
}
