using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace allopromo.Api.Validators
{
    public class ProductCategoryValidator : IValidator
    {
        bool IValidator.CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }

        IValidatorDescriptor IValidator.CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        ValidationResult IValidator.Validate(IValidationContext context)
        {
            throw new NotImplementedException();
        }

        Task<ValidationResult> IValidator.ValidateAsync(IValidationContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
