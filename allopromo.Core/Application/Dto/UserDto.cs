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
        public string userEmail { get; set; }
        public string Password { get; set; }
    }
    public class UserConvertor
    {
        public UserDto ConvertToDto(ApplicationUser appUser)
        {
            UserDto userDto = null;
            userDto.userName = appUser.UserName;
            userDto.userEmail = appUser.Email;
            return userDto;
        }
    }
}
