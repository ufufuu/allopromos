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
using allopromo.Core.Domain;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using allopromo.Core.Entities;
namespace allopromo.Controllers
{
    public delegate bool StoreCreatedEventHandler (object source, EventArgs e);
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        //public event StoreCreatedEventHandler StoreCreated; 
        //, IConfiguration config
        private readonly UserManager<ApplicationUser> _userManager;
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        private INotifyService _notificationService; // { get; set; }
        private IProductService _productService;
        //public StoreCreatedEventArgs storeCreated { get; set; }
        //public event EventHandler<string> _storeCreated;
        public StoreController(IStoreService storeService, IProductService productService,
            INotifyService notificationService)
        {
            _storeService = storeService;
            _productService = productService;
            _notificationService = notificationService;
        }
        //public StoreController(IStoreService storeService, IProductService productService)
        //{
        //    _storeService = storeService;
        //}
        [HttpPost]
        [Route("{categories}/{create}")]
        public async Task<IActionResult> PostStoreCategory([FromBody] StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return null;
            return Ok(_storeService.CreateStoreCategory(storeCategory.storeCategoryName));
        }
        [HttpPost]
        [Route("create")]
        [BasicJwtAuthorize]
        public async Task<IActionResult> CreateStoreAsync([FromBody] StoreDto storeDto)// StoreDto
        {
            if (storeDto != null) 
            {
                var category = new StoreCategoryDto();
                object user = null; //await GetConnectedUser();
                _storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;
                var store = _storeService.CreateStore(storeDto, category, (UserDto)user);
                if (store != null)
                {
                    _storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;
                    _storeService.OnStoreCreated();
                int Y = 6;
                    return Ok(store);
                }
                return NotFound();
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Route("{categories}/{products}/create")]
        [JwtBasicAuthorize]
        //api/stores/products/create? /product/categories/create ?
        public async Task<IActionResult> CreateProductAsync([FromBody] tProduct product)
        {
            ApplicationUser user = null;//=await GetConnectedUser();
            //ProductDto productDtoo = null;
            //productDtoo.productStatus = 1;
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var productDto = await _productService.CreateAsync(product);
                return CreatedAtAction(nameof(productDto), new { }, product);
            }
        }
        //[HttpGet]
        //[Route("{categoryId}/{pageNumber}/{limitPerPage}")]
        ////[Route("categoryId?limit=10&offSet=4")]
        //public async Task<IActionResult> GetStoresByCategoryIdAsync(int categoryId, int pageNumber, int limitPerPage)
        //{
        //    limitPerPage = 10;
        //    if (categoryId == null)
        //        return NotFound();
        //    else
        //    {
        //        var stores = await ((Task<IEnumerable<StoreDto>>)_storeService
        //            .GetStoresByCategoryIdAsync(categoryId, pageNumber , limitPerPage));
        //        return Ok(stores);
        //    }
        //}
        [HttpDelete]
        [Route("{locationId}/{pageNumber}/{limitPerPage}")]
        //[Route("categoryId?limit=10&offSet=4")]
        public async Task<IActionResult> GetStoresByLocationIdAsync(int locationId, int categoryId, int pageNumber, int limitPerPage)
        {
            limitPerPage = 10;
            if (categoryId.Equals(null))
                return NotFound();
            else
            {
                var stores = await ((Task<IEnumerable<StoreDto>>)_storeService
                    .GetStoresByCategoryIdAsync(categoryId, pageNumber, limitPerPage));
                return Ok(stores);
            }
        }
        [HttpPut]
        public ActionResult<StoreDto> GetStoresByIdAsync([FromBody] StoreData storeData)
        {
            var store = _storeService.GetStoreByIdAsync(storeData.storeData);
            if (store == null)
                return NotFound();
            return Ok(store);
        }
        //[HttpGet]
        //[Route("Id")]
        //public ActionResult<StoreDto> GetStoreByStoreIdAsync(string Id)
        //{
        //    if (Id.Equals(null))
        //        return null;
        //    return Ok(_storeService.GetStoreByIdAsync(Id));
        //}
        //[HttpGet]
        ////[Route("{storeId}/{category}/{products}")]
        //public async Task<IActionResult> GetProductsByCategories(string storeId)
        //{
        //    if (storeId == null)
        //        return NotFound();
        //    return Ok(await _productService.GetProductsByStore(storeId));
        //}
        [HttpGet]
        [Route("{categories}")]
        public async Task<IActionResult> GetStoreCategories()
        {
            var storeCategories =  await _storeService.GetStoreCategoriesAsync();
            return Ok(storeCategories);
        }
        [HttpGet]
        [Route("{category}/{Id}/{products}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(string Id)
        {
            var products = _productService.GetProductsByCategoryId(Id);
            return Ok(products);
        }
        [HttpGet]
        [Route("{products}/{catgories}")]
        public async Task<IActionResult> GetProducts()
        {
            var products = _productService.GetProductsByStore();
            return Ok(products);

            //return await _context.TodoItems
            //    .Select(x => ItemToDTO(x))
            //    .ToListAsync();

        }
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProduct(string Id)
        {
            var product = await _productService.GetProductsByCategoryId(Id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        //private async Task<UserDto> GetConnectedUser()
        //{
        //  var user2 = new UserDto { userName = "dkalskd", Password = "kskndsnd", userEmail = "adasd@frrf" };
        //  //var user = Mapper.Map<UserDto>(await _userManager.FindByIdAsync(User.Identity.Name));
        //  return user2;

        [HttpDelete]
        [Route("{categories}/{delete}")]
        public async Task<IActionResult> DeleteStoreCategory([FromBody] StoreCategoryDto storeCategoryDto)
        {
            if (storeCategoryDto == null)
                return null;
            return Ok();
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
    {   public enum orderStatus { Requested, Aknowledged, Started, Finished, Picked, Delivered };
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
//ActionExecutingContext actionContext)bwith [BasicJwt Attrib]!

//return Unauthorized();
//Secured Api Action

/* 4.. Shared kernel  Project ::::
 * Base Entity - Base value Object - Base Domain Events -Base specications - Common INterface
 * Common Exceptions - Comom Auth - Common Guards - Common Libraries , DI, Loggin, Validators
/****
 * 
 * Api Endpoint- Razor pages - Controllers - Views  - Api Models - ViewModels - Filters - Mmodel Binders -Tag Helpers
 * 
 * Interface rrurn types 
 *  COmpostion Root ?
 **
//Infrastructure Prject:
//Repositoriies - Api Clients ?  - DbContext Classes  - Cached Repositories  - File System Accessort - Azure Storeage
//Accessort - Emimailing Implement - SMS implementations - System Clock - Other Services , Interfaces 

///*github.com/ardalis/CleanArchitecture 
/*Ardalis Clean Archiecture Template from nuget 
/* CORE, What Beloing in the Core Project 
 * Interface
 * 
 * Aggregates (grouoing Entiites)
 * ValuesObjects( time , not Id contrary to Entities
 * 
 * Domain Services
 * 
 * Domain Exceptions 
 * Domain Events 
 * Evendt Handlers
 * 
 * Specification : library  ?
 * Validations : fluent Validation lib
 * Enurms
 * Custom Guards ? 
 * 
 *
 */