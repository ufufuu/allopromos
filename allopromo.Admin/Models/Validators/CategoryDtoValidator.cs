using allopromo.Admin.Models.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Models.Validators
{
    public class StoreCategoryDtoValidator: AbstractValidator<StoreCategoryDto>
    {
        public StoreCategoryDtoValidator()
        {
            RuleFor(x => x.storeCategoryName).NotNull().Length(3, 25);
            //RuleFor(x => x.isParent).NotNull();
        }
    }
}


//stored proc vs views?