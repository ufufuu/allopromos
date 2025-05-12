
using allopromo.Api.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace allopromo.Api.Validators
{
    public class CreateUserValidator :
        FluentValidation.AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
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