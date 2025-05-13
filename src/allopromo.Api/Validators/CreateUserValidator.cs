
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
                .WithMessage(" Create User name Should Not Be Empty from Fluent ");
            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage(" Create User password Should Not Be Empty from Fluent ");
        }
    }
}