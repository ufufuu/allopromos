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
    public class CreateUserValidator : FluentValidation.IValidator<CreateUserDto>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(CreateUserDto instance)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(IValidationContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(CreateUserDto instance, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
