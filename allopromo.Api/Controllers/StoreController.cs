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
        public event StoreCreatedEventHandler StoreCreated; //, IConfiguration config
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        private IProductService _productService;
        private INotificationService _notificationService { get; set; }
        public StoreCreatedEventArgs storeCreated { get; set; }
        public event EventHandler<string> _storeCreated;
        private IStoreQuery _storeQuery;
        public StoreController(IStoreService storeService, INotificationService notificationService)
        {
            _storeService = storeService;
            _notificationService = notificationService;
        }
        public StoreController(IStoreService storeService, IConfiguration config,
            INotificationService notificationService, IStoreQuery storeQuery)
        {
            _storeService = storeService;
            _notificationService = notificationService;
            _storeQuery = storeQuery;
        }
        protected virtual void OnStoreCreated()
        {
            if (StoreCreated != null)
            {
                StoreCreated(this, StoreCreatedEventArgs.Empty);
            }
        }
        [HttpGet]
        public ActionResult<StoreDto> GetStoreByIdAsync([FromBody] StoreData storeData)
        {
            var store = _storeQuery.GetStoreByIdAsync(storeData.storeData);
            if (store == null)
                return null;
            return Ok(store);
        }
        [HttpGet]
        [Route("Id")]
        public ActionResult<StoreDto> GetStoreByIdAsync(string Id)
        {
            return null;
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetStoresByCatId(string catId)
        {
            if (catId == null)
                return NotFound();
            else
            {
                var stores = await ((Task<List<StoreDto>>) _storeService.GetStoresByCatIdAsync(catId));
                return Ok(stores);
            }
        }
        [HttpGet]
        [Route("{store}/{products}")]
        public async Task<IEnumerable<ProductDto>> GetProductsByCategories(string storeId)
        {
            if (storeId == null)
                return null;
            return await _productService.GetProductsByStore(storeId);
        }
        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Test")]
        //[Authorize(Roles = "users")]
        [Route("create")]
        //[BasicAuthenticationFilter]

        //[Authorize(AuthenticationSchemes = "Test")]


        //[BasicJwtAuthorize] //vs [AuthorizeAttribute]?
        public IActionResult CreateStore()//ActionExecutingContext actionContext)bwith [BasicJwt Attrib] !
        {
            //if (storeDto != null)
            {
              //  var store = _storeService.CreateStore(storeDto);

            }
            return NotFound();
        }
        public IActionResult CreateStoreAsync(StoreDto storeDto)
        {
            return null;
        }

        [HttpPost]
        [Route("create")]

        // ? Custom Authorization ?
        //[allopromo.Infrastructure.Providers.BasicAuthenticationFilter]
        //[Authorize(AuthenticationSchemes ="Test")]

        public IActionResult CreateStoreS([FromBody] StoreDto store)// StoreDto
        {
            if (store != null)
            {
                StoreCreated +=_notificationService.StoreCreatedEventHandler;

                //_storeService.storeCreated += _notificationService.StoreCreatedEventHandler;
                //_storeService.OnStoreCreated();
                //OnStoreCreated(store.storeName + " is Created");

                OnStoreCreated();
                //var d_store = _storeService.CreateStore((Store)TConvertor.ConvertObjToStore((object)store));
                var storeDto = _storeService.CreateStore(store);
                return Ok(store);
            }
            return Unauthorized();
        }
    }
    public class StoreData
    {
        public string storeData { get; set; }
    }
    
    //Delegates
    public delegate string mydelegate(string msg);

    //Generic Delegates
    public delegate string myGenericDelegate<T>(string msg);
    //Structs
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
    //Direct Casting vs Operator casting

    //Extensions Methods 0001-01-01 00:00:00.0000000
    public static class MyExtensionClass
    {
        //Extension Class 
        public static int MyExtensionMethod(this int v)
        {
            return 4;
        }
    }
    //Singleton Pattern : Why Use ?
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

    //Other Patterns ?
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
