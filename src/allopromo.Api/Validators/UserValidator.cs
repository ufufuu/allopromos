using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using allopromo.Api.DTOs;
using FluentValidation;
using FluentValidation.Results;

namespace allopromo.Api.Validators
{
    public class UserValidator : IValidator<UserDto>
    {
        bool IValidator.CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }

        IValidatorDescriptor IValidator.CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        ValidationResult IValidator<UserDto>.Validate(UserDto instance)
        {
            throw new NotImplementedException();
        }

        ValidationResult IValidator.Validate(IValidationContext context)
        {
            throw new NotImplementedException();
        }

        Task<ValidationResult> IValidator<UserDto>.ValidateAsync(UserDto instance, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        Task<ValidationResult> IValidator.ValidateAsync(IValidationContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
