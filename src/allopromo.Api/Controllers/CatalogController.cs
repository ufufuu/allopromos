
using allopromo.Core.Abstract;
using allopromo.Core.Interfaces;
using allopromo.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;

namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IVendorService _vendorService;
        private readonly IConfiguration _config;
        public CatalogController(
          IConfiguration config,
          ICatalogService catalogService,
          IVendorService vendorService)
        {
            _vendorService = vendorService;
            _catalogService = catalogService;
            _config = config;

        }
        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IActionResult> GetCategory(string categoryId)
        {
            if(categoryId != null)
            {
                var category = (await _catalogService.GetProductCategories())
                            .Where(x => x.productCategoryId.Equals(categoryId));
                return Ok(categoryId);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{merchandId}/products")]
        public async Task<IActionResult> GetVendorProducts(string vendorId)
        {
            if (vendorId == null)
                return BadRequest();
            var products = (await _catalogService.GetProductsByStore(vendorId));
            return Ok(products);
        }

    }
}
