using allopromo.Core.Abstract;
using allopromo.Core.Helpers.Convertors;
using System;
using System.Collections.Generic;
using allopromo.Core.Application;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;
namespace allopromo.Core.Model
{
    //public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    //What are Service Layers in Practice anyway ?
    public class StoreService : IStoreService

    {
        public event StoreCreatedEventHandler storeCreated;
        private IStoreQuery _storeQuery;
        private IProductService _productService;
        private IStoreRepository _storeRepo;
        // ? Builder !

        //public UnitOfWork _unitOfWork { get; set; }
        // IOC by DIP
        //IGenericsRepository _repo = GenericRepositoryFactory.GetRepository();

        //IQuery Pattern ?
        public StoreService(IStoreRepository storeRepo)
        {
            storeRepo = storeRepo;
        }
        public StoreService(IStoreQuery storeQuery)
        {
            //_repo = repo;
            _storeQuery = storeQuery;
        }
        public void OnStoreCreated()
        {
            if (storeCreated != null)
            {
                storeCreated(this, EventArgs.Empty);
            }
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByStoresAndCategories(string storeId)
        {
            if (storeId == null)
                return null;
            return await _productService.GetProductsByStore(storeId);
        }
        public IEnumerable<StoreDto> GetStoresAsync(int page, int size)
        {
            return null;
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByCatIdAsync(string catId)
        {
            if(catId==null)
                return null;
            //return new StoreConvertor().ConvertStores(
            //(List<tStore>)await _storeQuery.GetStoresByCatIdAsync(catId));
            return null;
        }
        public async Task<StoreDto> GetStoreByIdAsync(string storeId)
        {
            if (storeId == null)
                return null;
            StoreCreatedEventHandler del = delegate
            {
                return true;
            };
            var tStore = await _storeQuery.GetStoreByIdAsync(storeId);
            var storeDto = new StoreConvertor().ConvertStore(tStore);
            if (storeDto == null)
                return null;    
            return storeDto;
        }
        public StoreDto CreateStore(StoreDto store)
        {
            //var dateCreated = DateTime.Now.Day;
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            if (store != null)
            {
                _storeQuery.CreateStore(store);
            }
            return null;
        }
        public void DeleteStore(StoreDto store)
        {
        } 
        public IEnumerable<StoreDto> GetStoresCategories()
        {
            return null;
        }
        async Task<StoreDto> GetStoreBy(string storeId)
        {
            var stores = await _storeQuery.GetStoreByIdAsync(storeId);
            return new StoreConvertor().ConvertStore(stores);
        }

        IEnumerable<StoreDto> IStoreService.GetStoresByCatIdAsync(string catId)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class NotifyServiceS
    {
        public void NotifyAll(List<string   > userNames)
        {
        }
        public void OnStoreCreated(object sender, EventArgs e)
        {
        }
    }
    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}
    public interface IPaymentMethod //if paymentMethod is Cash at Delivery - Mobile X - Credit - Card ?
    {
    }
    public interface IProduct
    {
    }
    ////return new StoreRepository().GetAllStores().AsEnumerable();//GetStoresCategories()
    //return _storeRepo.GetAllStores().AsEnumerable();//(page, size).AsEnnumerable();
}
/* 1. table jointure
 * 2. re architecture
 * 3. I QUery Patterns
 */