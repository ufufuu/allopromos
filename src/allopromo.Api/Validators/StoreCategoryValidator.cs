using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using allopromo.Core.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace allopromo.Api.Validators
{
    public class StoreCategoryValidator : AbstractValidator<StoreCategory>
    {
    }
}
