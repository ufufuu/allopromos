using allopromo.Admin.Models.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Models.Validators
{
    public class UserDtoValidator:AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().Length(3,25);
            RuleFor(x => x.UserPwd).NotNull().Length(6, 20);
        }
    }
}
