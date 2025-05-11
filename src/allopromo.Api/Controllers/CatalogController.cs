
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

        #region Categories
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var storeCategories = await _catalogService.GetStoreCategories();
            if (storeCategories != null)
                return Ok(storeCategories);
            return NotFound();
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
        #endregion

        #region Vendors
        [HttpGet]
        [Route("{categoryId}/vendors")]
        public async Task<ActionResult> GetVendorsByCategory(string categoryId)
        {
            if (categoryId == null)
                return BadRequest();
            var vendors = _catalogService.GetVendors();
            return Ok(vendors);
        }
        #endregion

        #region Products
        [HttpGet]
        [Route("{merchandId}/products")]
        public async Task<IActionResult> GetProductsByVendor(string vendorId)
        {
            if (vendorId == null)
                return BadRequest();
            var products = (await _catalogService.GetProductsByStore(vendorId));
            return Ok(products);
        }
        #endregion
    }
}
