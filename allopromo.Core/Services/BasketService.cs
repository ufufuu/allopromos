using allopromo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class BasketService : Interfaces.IBasketService
    {
        private readonly Abstract.IRepository<Basket> _basketRepository;

        //private readonly IAppLogger<BasketService> _logger;
        public BasketService(Abstract.IRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;

            //_logger = logger;
        }
        public Task<Basket> AddItemToBasketAsync(string userName, int catalogItemId, decimal price, int quantity=1)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBasketAsync(int basketId)
        {
            throw new NotImplementedException();
        }

        public Task TransferBasketAsync(string anonymoudId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
