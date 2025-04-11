
using allopromo.Core.Abstract;
using allopromo.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly
#nullable disable
    IConfiguration _config;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IVendorService _merchantService;

        public CatalogController(
          IConfiguration config,
          IProductService productService,
          ICategoryService categoryService,
          IVendorService merchantService)
        {
            this._config = config;
            this._productService = productService;
            this._categoryService = categoryService;
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IActionResult> GetCategory(string categoryId) => (IActionResult)this.Ok();

        [HttpGet]
        [Route("products/{categoryId}")]
        public async Task<IActionResult> GetCategoryProducts(string categoryId)
        {
            return (IActionResult)this.Ok();
        }

        [HttpGet]
        [Route("{merchandId}/products")]
        public async Task<IActionResult> GetVendorProducts(string vendorId)
        {
            return (IActionResult)this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search() => (IActionResult)this.Ok();
    }
}
