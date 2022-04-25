using allopromo.Core.Abstract;
using allopromo.Core.Helpers.Convertors;
using System;
using System.Collections.Generic;
using allopromo.Core.Application;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
namespace allopromo.Core.Model
{
    public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
    public class StoreService : IStoreService
    {
        public event StoreCreatedEventHandler storeCreated;
        event Abstract.StoreCreatedEventHandler IStoreService.storeCreated
        {
            add
            {
                //throw new NotImplementedException();
            }

            remove
            {
               // throw new NotImplementedException();
            }
        }
        public Action<string> StoreCreated;
        private IStoreQuery _storeQuery;
        private IProductService _productService;
        private IStoreRepository _storeRepository;
        IGenericRepository<tStore> _TRepository; // = GenericRepositoryFactory.GetRepository();
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public void OnStoreCreated()
        {
            if (storeCreated != null)
            {
                storeCreated(this, EventArgs.Empty);
            }
        }
        public StoreDto CreateStore(StoreDto store)
        {
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            if (store != null)
            {
                var t_store = TConvertor.ConvertToObj(store);
                _storeRepository.Add(t_store as tStore);

                //_TRepository.Add(t_store as tStore);
                //_TRepository.Save();

                OnStoreCreated();
                return (StoreDto)store;
            }
            return null;
        }
        public tStoreCategory CreateStoreCategory(StoreCategoryDto storeCategory)
        {
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            //if (storeCategory != null)
            //{
                var t_store = TConvertor.ConvertToObj(storeCategory);
                _storeRepository.AddCategory(t_store as tStoreCategory);

                return new tStoreCategory { storeCategoryId=1, storeCategoryName="rlelel"};
                //return (tStoreCategory)t_store;
            //}
            //int y = 67;
            //return null;
        }
        public async Task<IEnumerable<StoreDto>> GetStoresByCategoryIdAsync(int categoryId, int pageNumber, int offSet)
        {
            offSet = 10;
            //if (categoryId == null)
              //  return null;
            //else
            //{
                var storesByCategory = TConvertor.
                    ConverToListObj(_storeRepository.GetStoresByCategoryIdAsync(categoryId, pageNumber, offSet));

                return storesByCategory as IEnumerable<StoreDto>;
            //}
            
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
       
        public void DeleteStore(StoreDto store)
        {
        } 
        
        async Task<StoreDto> GetStoreBy(string storeId)
        {
            var stores = await _storeQuery.GetStoreByIdAsync(storeId);
            return new StoreConvertor().ConvertStore(stores);
        }
        public IEnumerable<StoreDto> GetStoreCategoriesAsync()
        {
            var storeCategories = _storeRepository.GetStoreCategoriesAsync();
            return (IEnumerable<StoreDto>)storeCategories;
        }

        //IEnumerable<StoreDto> IStoreService.GetStoresByCatIdAsync(string catId)
        //{
        //    throw new NotImplementedException();
        //}

    }
    public interface IPaymentMethod //if paymentMethod is Cash at Delivery - Mobile X - Credit - Card ?
    {
    }
    public interface IProduct
    {
    }

    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}

    ////return new StoreRepository().GetAllStores().AsEnumerable();//GetStoresCategories()
    //return _storeRepo.GetAllStores().AsEnumerable();//(page, size).AsEnnumerable();
}
/* 1. table jointure
 * 2. re architecture
 * 3. I QUery Patterns
 */


// ? Builder !

//public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
//What are Service Layers in Practice anyway ?
//public UnitOfWork _unitOfWork { get; set; }
// IOC by DIP
//IGenericsRepository _repo = GenericRepositoryFactory.GetRepository();

//IQuery Pattern ?