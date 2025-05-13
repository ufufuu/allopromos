
using allopromo.Api.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace allopromo.Api.Validators
{
    public class CreateVendorValidator : 
        FluentValidation.AbstractValidator<VendorDto>
    {
        
    }
}
