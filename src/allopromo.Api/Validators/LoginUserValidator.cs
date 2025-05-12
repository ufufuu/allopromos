
using allopromo.Api.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace allopromo.Api.Validators
{
    public class LoginUserValidator : 
        FluentValidation.AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(model => model.UserName)
                .NotEmpty()
                .WithMessage("User name Should Not Be Empty");
            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage("User password Should Not Be Empty");
        }
    }
}
