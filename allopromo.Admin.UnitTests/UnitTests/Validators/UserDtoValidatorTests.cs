using allopromo.Admin.Models.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using allopromo.Admin.Models.Dto;
using FluentValidation.TestHelper;
namespace allopromo.Admin.UnitTests.UnitTests.Validators
{
    [TestFixture]
    public class UserDtoValidatorTests
    {
        private UserDtoValidator userDtoValidator { get; set; }
        public UserDtoValidatorTests()
        {
            userDtoValidator = new UserDtoValidator();
        }
        [Test]
        public void Should_Have_Error_When_Name_Null()
        {
            var person = new UserDto() { UserName = null, UserPwd = "" };
            var result = userDtoValidator.TestValidate(person);
            //result.ShouldHaveValidationErrorFor(person.UserName);
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }
        [Test]
        public void Should_not_have_error_when_name_is_specified()
        {
            var userDto = new UserDto { UserName = "Keving Djounam", UserPwd = "@irjikmaKdn" };
            var result = userDtoValidator.TestValidate(userDto);
            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        }
    }
}
