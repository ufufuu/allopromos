
using allopromo.Core.Abstract;
using allopromo.Core.Interfaces;
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
        private readonly ICatalogService _catalogService;
        private readonly IVendorService _merchantService;

        public CatalogController(
          IConfiguration config,
          IProductService productService,
          ICatalogService catalogService,
          IVendorService merchantService)
        {
            _config = config;
            _productService = productService;
            _catalogService = catalogService;
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
