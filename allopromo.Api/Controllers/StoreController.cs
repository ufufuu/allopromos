using allopromo.Core.Model;
using allopromo.Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNet.SignalR.Messaging;
using allopromo.Core.Helpers;
using System.Threading.Tasks;
using allopromo.Core.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;
using allopromo.Core.Application.Dto;
namespace allopromo.Controllers
{
    public delegate bool StoreCreatedEventHandler (object source, EventArgs e);
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        //public event StoreCreatedEventHandler StoreCreated; 
        //, IConfiguration config
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        private INotifyService _notificationService; // { get; set; }
        private IProductService _productService;
        //public StoreCreatedEventArgs storeCreated { get; set; }
        //public event EventHandler<string> _storeCreated;
        private IStoreQuery _storeQuery;
        public StoreController(IStoreService storeService,
            INotifyService notificationService)
        {
            _storeService = storeService;
            _notificationService = notificationService;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateStoreAsync([FromBody] StoreDto store)// StoreDto
        {
            if (store != null) 
            {
                var storeDto = _storeService.CreateStore(store);

                if (storeDto != null)
                {
                    _storeService.storeCreated += _notificationService.StoreCreatedEventHandler;
                    _storeService.OnStoreCreated();
                    return Ok(store);
                }
                return null;
            }
            return Unauthorized();
        }
        [HttpGet]
        [Route("{categoryId}/{pageNumber}/{limitPerPage}")]
        //[Route("categoryId?limit=10&offSet=4")]
        public async Task<IActionResult> GetStoresByCategoryIdAsync(int categoryId, int pageNumber, int limitPerPage)
        {
            limitPerPage = 10;
            if (categoryId == null)
                return NotFound();
            else
            {
                var stores = await ((Task<IEnumerable<StoreDto>>)_storeService
                    .GetStoresByCategoryIdAsync(categoryId, pageNumber , limitPerPage));
                return Ok(stores);
            }
        }
        [HttpGet]
        public ActionResult<StoreDto> GetStoresByIdAsync([FromBody] StoreData storeData)
        {
            var store = _storeQuery.GetStoreByIdAsync(storeData.storeData);
            if (store == null)
                return null;
            return Ok(store);
        }
        [HttpGet]
        [Route("Id")]
        public ActionResult<StoreDto> GetStoreByStoreIdAsync(string Id)
        {
            return null;
        }
        [HttpGet]
        [Route("{store}/{products}")]
        public async Task<IEnumerable<ProductDto>> GetProductsByCategories(string storeId)
        {
            if (storeId == null)
                return null;
            return await _productService.GetProductsByStore(storeId);
        }
        [HttpPost]
        [Route("{categories}/{create}")]
        public async Task<IActionResult> PostStoreCategory([FromBody] StoreCategoryDto storeCategory)
        {
            return Ok(_storeService.CreateStoreCategory(storeCategory));
        }
        [HttpGet]
        [Route("{categories}")]
        public async Task<IActionResult> GetStoreCategories()
        {
            var storeCategories =  _storeService.GetStoreCategoriesAsync();
            return Ok(storeCategories);
        }
    }
    public class StoreData
    {
        public string storeData { get; set; }
    }
    public delegate string mydelegate(string msg);
    public delegate string myGenericDelegate<T>(string msg);
    public struct DeliveryStatus
    {
    }
    enum DeliveryStatuts
    {
    }
    public class PhoneNumber
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public PhoneNumber(string n, string num)
        {
            Name = n;
            Number = num;
        }
    }
    public class Friend : PhoneNumber
    {
        public bool IsWorkNumber { get; set; }
        public Friend(string m, string num, bool wk) : base(m, num)
        {
            IsWorkNumber = wk;
        }
    }
    public class PhoneList<T> where T : PhoneNumber
    {
    }
    public enum Action
    {
        Start, Stop, Forwad, Reverse
    }
    public class OrderStatut
    {
        public enum orderStatus { Requested, Aknowledged, Started, Finished, Picked, Delivered };
    }
    public static class MyExtensionClass
    {
        public static int MyExtensionMethod(this int v)
        {
            return 4;
        }
    }
    public class StoreCreatedSingleton
    {
        private static readonly StoreCreatedSingleton _instance = new StoreCreatedSingleton();
        public static StoreCreatedSingleton Instance { get { return _instance; } }
        static StoreCreatedSingleton() { }
        private StoreCreatedSingleton() { }
        public event EventHandler<Message> _storeCreated;
        public virtual void OnStoreCreated(Message msg)
        {
            if (_storeCreated != null)
            {
                _storeCreated(this, msg);
            }
        }
    }
    public class SingleObject
    {
        private static SingleObject instance = new SingleObject();
        private SingleObject()
        {
        }
        public static SingleObject getInstance()
        {
            return instance;
        }
    }
}
/*
 * https://www.c-sharpcorner.com/article/learn-about-web-api-validation/
 * 
 * Number of occurence in a Word , number of words in a Phrase !
 */
/* Asynchronous Method vs , whhen should I make a methdos Asynchronous ? What are Callbacks ?
 */
/* Fields vs Properties ??? */
/* Store Servcice having StoerRepo as Fields ? Why ?
 */
/*
 * //Singleton Pattern : Why Use ? //Extension Class  //Extensions Methods 0001-01-01 00:00:00.0000000 //Direct Casting vs Operator casting
 * 
 * */
/*
 * //[Authorize(AuthenticationSchemes = "Test")]
        //[Authorize(Roles = "users")]
*/
//[Authorize(AuthenticationSchemes = "Test")]//[BasicAuthenticationFilter]//[BasicJwtAuthorize] //vs [AuthorizeAttribute]?

//Delegates //Generic Delegates //Structs

//[Authorize(AuthenticationSchemes ="Test")] //[allopromo.Infrastructure.Providers.BasicAuthenticationFilter]
        // ? Custom Authorization ?
        //ActionExecutingContext actionContext)bwith [BasicJwt Attrib] !