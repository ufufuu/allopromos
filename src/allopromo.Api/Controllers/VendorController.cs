
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using allopromo.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private
#nullable disable
    UserManager<ApplicationUser> _userManager
        { get; set; }

        private IHttpContextAccessor _httpContextAccessor { get; set; }

        private IVendorService _vendorService { get; set; }

        private ICustomerService _customerService { get; set; }

        private IUserService _userService { get; set; }

        public VendorController(
          UserManager<ApplicationUser> userManager,
          IHttpContextAccessor httpContextAccessor,
          ICustomerService customerService,
          IUserService userService,
          IVendorService vendorService)
        {
            this._userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            this._vendorService = vendorService;
            this._customerService = customerService;
            this._userService = userService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetVendor(string Id)
        {
            var vendor = await _vendorService.GetVendor(Id);
            if (vendor != null)
                return Ok(vendor);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        [Route("{userName}")]
        public async Task<IActionResult> ApplyVendorSubmit([FromBody] string userName)
        {
            VendorController vendorController = this;
            if (!vendorController.ModelState.IsValid)
                return (IActionResult)vendorController.NotFound();
            bool flag = await vendorController._userService.UpdateUserRole("Merchants", userName);
            return (IActionResult)vendorController.Ok((object)true);
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult RemovePicture() => (IActionResult)this.Ok();
    }
}
