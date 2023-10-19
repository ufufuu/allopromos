using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public class Basket
    {

    }
    public interface IBasketService
    {
        public Task<Basket> AddItemToBasketAsync(string userName, int catalogItemId, decimal price, int quantity=1);
        public Task TransferBasketAsync(string anonymoudId, string userName);


        //Task<Result<Basket>> SetQuantities(int basketId, Dictionary<string, int> quantities);
        public Task DeleteBasketAsync(int basketId);
    }
}
