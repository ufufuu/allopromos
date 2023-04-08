using allopromo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.Application.Dto
{
    public class UserDto
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string userRoleName { get; set; }


        //public List<RoleDto> Roles { get; set; }
        //public string UserRoles { get; set; }

        public UserDto()
        {}
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
