using allopromo.Core.Model;
using allopromo.Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;
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
using System.Net;
using System.ComponentModel;
using System.Net.Http;
using allopromo.Core.Services;

namespace allopromo.Api.Controllers
{
    public delegate bool StoreCreatedEventHandler (object source, EventArgs e);
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        #region "Events"
        //public event StoreCreatedEventHandler StoreCreated; 
        //IConfiguration config
        //public StoreCreatedEventArgs storeCreated { get; set; }
        //public event EventHandler<string> _storeCreated;
        // What would read-only change here vs private ?
        #endregion
        #region  "Constantes & Properties"
        private const string BASE_API = "api/v1/store";
        #endregion
        #region "Properties"
        private readonly ILocalisationService LocalisationService;
        private readonly IStoreService _storeService;
        private readonly Core.Abstract.ICategorieService _categoryService;
        private readonly INotifyService _notificationService;
        private readonly IProductService _productService;
        public Core.Services.MediaService _mediaService { get; set; }
        #endregion
        #region"Constructors & Methods"
        public StoreController(IStoreService storeService, 
            IProductService productService, 
            Core.Abstract.ICategorieService categorieService,
            INotifyService notificationService)
        {
            _storeService = storeService;
            _productService = productService;
            _notificationService = notificationService;
            _categoryService = categorieService;
        }
        [HttpPost]
        [Route("categories/create/categoryId")]
        public async Task<IActionResult> PostStoreCategory([FromBody] 
            StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return BadRequest();
            return Ok(await _categoryService.CreateStoreCategoryAsync(storeCategory));
        }
        [HttpPost]
        [Route("create")]
        //[BasicJwtAuthorize]
        public IActionResult CreateStoreAsync(//[FromBody] StoreDto storeDto)
            string  storeDtoName)
        {
            if (storeDtoName != null)
            {
                var category = new StoreCategoryDto();
                object user = null;
                _storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;
                var store = _storeService.CreateStore(storeDtoName);//, category, (UserDto)user);
                if (store != null)
                {
                    _storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;
                    _storeService.OnStoreCreated();
                    return Ok(store);
                }
                return NotFound();
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Route(ConstancesCommunes.BaseUrl+"{categories}/{products}/create")]
        //[SwaggerResponse(HttpStatusCode.OK,Description="CreateProduct", Type=typeof(StoreCategoryDto))]
        [JwtBasicAuthorize]
        public async Task<IActionResult> CreateProductAsync([FromBody] tProduct product)
        {
            ApplicationUser user = null;
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
        [Route("categories/{catId}")]
        public ActionResult PutStoreCategory([FromBody] StoreCategoryDto category)
        {
            string catId = string.Empty;
            //var store = await _storeService.GetStoreCategoryByIdAsync(catId); //storeData.storeCategoryId);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                catId = category.storeCategoryId;
                _categoryService.UpdateStoreCategory(catId.ToString(), category);
                return Ok(category);
            }
        }
        [HttpPut]
        [Route("")]
        public ActionResult<StoreDto> GetStoresByIdAsync([FromBody] Object storeData)
        {
            var store = _storeService.GetStoreByIdAsync(storeData.ToString());
            if (store == null)
                return NotFound();
            return Ok(store);
        }
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetStoreCategories()
        {
            var storeCategories = await _categoryService.GetStoreCategoriesAsync();
            if(storeCategories!=null)
                return Ok(storeCategories);
            return BadRequest();
        }
        [HttpGet]
        [Route("category/{Id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(string Id)
        {
            var storeCategory = await _categoryService.GetStoreCategoryAsyncById(Id); // GetStoreByIdAsync(Id);
            return Ok(storeCategory);
        }
        [HttpGet]
        [Route("{category}/{Id}/{products}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(string Id)
        {
            var products = await  _productService.GetProductsByCategoryId(Id);
            return Ok(products);
        }
        [HttpGet]
        [Route("{products}/{categories}")]
        public async Task<IActionResult> GetProducts()
        {
            var products =await  _productService.GetProductsByStore();
            return Ok(products);
        }
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProduct(string Id)
        {
            var product = await _productService.GetProductsByCategoryId(Id);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }
        [HttpDelete]
        [Route("categories/delete/id")]
        public IActionResult DeleteStoreCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }
            else
            {
                _categoryService.DeleteStoreCategory(categoryId);
                return Ok(true);
            }
        }
        #endregion

        //[HttpGet]
        //[Route("{categories}/images")]
        //public async Task<IActionResult> getImageAsync()
        //{
        //    var image = await _storeService?.getImageUrl();
        //    if (image == null)
        //        return BadRequest();
        //    return Ok(image);
        //}

        //[HttpPatch]
        //[Route("categories/images/{mediaUrl}")]
        //public bool SaveThumbnailImage(string mediaUrl)
        //{
        //    return false;
        //    //_storeService.postStoreCategoryImage();
        //    bool gr = true;
        //    if(gr)
        //        return true;
        //    else
        //        return false;
        //}
    }
    public delegate string mydelegate(string msg);
    public delegate string myGenericDelegate<T>(string msg);
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
 * Validations : fluent Validation libGet
 * Enurms
 * Custom Guards ? 
 */

//[SwaggerResponse(HttpStatusCode.OK , Description= "xxx Enregistree dans l\'Antememoire",
//Type=typeof(StoreCategoryDto))]