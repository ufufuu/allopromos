using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace allopromo.Core.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        private readonly IHttpContextAccessor _contextAccessor;
        private Abstract.IRepository<Core.Model.CartItem> cartRepository { get; set; }
        public ShoppingCartActions(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void Dispose()
        {}

        public void AddToCart(allopromo.Core.Entities.Product product)
        {
            var cartItem = cartRepository.GetAllAsync().Result.AsEnumerable().SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.cartItemId == product.productId.ToString());
            if(cartItem ==null)
            {
                cartItem = new Core.Model.CartItem
                {
                    cartItemId = System.Guid.NewGuid().ToString(),
                    ProductId = product.productId,
                    CartId = ShoppingCartId,
                    //product = p
                    Quantity = 1,
                    DateCreated = DateTime.Now,
                };
                cartRepository.Add(cartItem);
            }
            else
            {
                cartItem.Quantity ++;
            }
            cartRepository.Save();
        }
        public string GetCartId( HttpContext httpContext)
        {
            var session = httpContext.Session;

            if(!session.Keys.Contains(CartSessionKey))
            {
                var userName = httpContext.User.Identity.Name;

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    session.SetString(CartSessionKey,userName);
                }
                else
                {
                    System.Guid tempCartid = System.Guid.NewGuid();
                    session.SetString(CartSessionKey,tempCartid.ToString());
                }
            }
            return session.GetString(CartSessionKey);
        }
        
        
        public List<Model.CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId(_contextAccessor.HttpContext);

            return cartRepository.GetAllAsync().Result.AsEnumerable().Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
        public void EmptyShoppingCart()
        {
        }
    }
}
