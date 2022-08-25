using allopromo.Admin.Models.Dto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Areas.Manage.Controllers
{
    public class StoresController : Controller
    {
        private IValidator<StoreCategoryDto> _storeCategoryValidator { get; set; }
        private ILogger<StoreCategoryDto> _storeCategoryLogger { get; set; }
        //private IConfi
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateStore()
        {
            return View("CreateStore");
        }
        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreDto storeDto)
        {
            var category = new StoreCategoryDto();
            ValidationResult result = await _storeCategoryValidator.ValidateAsync(category);
            if(!result.IsValid)
                return null;
            else
                return null;
        }
    }
}
