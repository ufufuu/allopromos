

using allopromo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly
#nullable disable
    IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this._shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        [ActionName("AddToCart")]
        public async Task<IActionResult> AddItemsToCart(Guid? customerId, IFormCollection form)
        {
            return (IActionResult)this.Ok();
        }

        [HttpGet]
        public IActionResult GetCartContent() => (IActionResult)this.Ok();
    }
}
