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
using allopromo.Api.Model.ViewModel.Page;
using System.Linq;
using allopromo.Api.Model.Wrappers;
using allopromo.Api.Model.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace allopromo.Api.Controllers
{
    public delegate bool StoreCreatedEventHandler (object source, EventArgs e);
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        //public event StoreCreatedEventHandler StoreCreated; 
        //, IConfiguration config
        //public StoreCreatedEventArgs storeCreated { get; set; }
        //public event EventHandler<string> _storeCreated;
        // What would read-only change here vs private ?
        //tiktak.ca/en/store/62143| 
        ////kijiji.ca/b-autos-vehicules/ville-de-quebec/c27l1700124
        //api/customer?pageNumber=3&pageSize=10;

        #region Constantes
        public int pageNumber { get; set; }
        public const int pageSize = 2;
        #endregion

        #region Fields
        private readonly IStoreService _storeService;
        private readonly INotifyService _notificationService;
        private readonly IProductService _productService;
        #endregion

        #region Constructors & Properties
        public delegate string mydelegate(string msg);
        public delegate string myGenericDelegate<T>(string msg);
        public Core.Services.MediaService _mediaService { get; set; }
        public HttpContextAccessor _httpContextAccessor { get; set; }
        public StoreController(IStoreService storeService, IProductService productService, 
            INotifyService notificationService)
        {
            _storeService = storeService;
            _productService = productService;
            _notificationService = notificationService;
        }
        #endregion

        #region POST create Categories and Stores
        [HttpPost]
        [Route("categories/create/")]
        public async Task<IActionResult> PostStoreCategory([FromBody]
            StoreCategoryDto storeCategory)
        {
            if (storeCategory == null)
                return BadRequest();
            return Ok(await _storeService.CreateStoreCategoryAsync(storeCategory));
        }
        [HttpPost]
        [Route("create")]
        //[Authorize]
        //[BasicJwtAuthorize]
        public IActionResult PostStoreAsync([FromBody] StoreDto storeDto)//,UserDto userDto)
        {
            if (storeDto != null)
            {
                var currentIdentity = User.Identity;

                //_storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;

                var store = _storeService.CreateStoreAsync(storeDto, currentIdentity.Name).Result;

                if (store != null)
                {
                    return Ok(store);

                    //_storeService.StoreCreated += _notificationService.StoreCreatedEventHandler;
                    //_storeService.OnStoreCreated();
                }
                return NotFound();
            }
            else
                return NotFound();
        }
        #endregion

        #region Create Products And Categories

        [HttpPost]
        [Route("products/create")]
        //[SwaggerResponse(HttpStatusCode.OK,Description="CreateProduct", Type=typeof(StoreCategoryDto))]
        [JwtBasicAuthorize]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDto product)
        {
            var httpContextAccessor = new HttpContextAccessor();
            var currentUser = httpContextAccessor.HttpContext.User.Identity;
            if (currentUser == null)
            {
                return Unauthorized();
            }
            else
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var tObj = AutoMapper.Mapper.Map<tProduct>(product);
                var productDto = await _productService.CreateProductAsync(product, currentUser.Name);
                return CreatedAtAction(nameof(productDto), new { }, product);
            }
        }
        #endregion create Products and Categories

        #region GET read
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetStores()//[FromQuery] PaginationFilter filter)
        {
            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var stores = await _storeService.GetStores();

            //var paginatedResult = stores
                                //.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                //.Take(validFilter.PageSize).AsQueryable();

            //var result = PaginatedList<StoreDto>.CreateAsync(stores.AsQueryable(), pageNumber, pageSize);
            if (stores == null)
                return NotFound();
            else
                return Ok(stores); //new PagedResponse<IEnumerable<StoreDto>>
                    //(paginatedResult, validFilter.PageNumber, validFilter.PageSize));
        }
        [HttpGet]
        [Route("{LocalizationId}")]
        public async Task<IActionResult> GetStoresByLocationId(string LocalizationId)
        {
            var stores = await _storeService.GetStores(LocalizationId);
            if (stores != null)
                return Ok(stores);
            return BadRequest();
        }
        [HttpGet]
        [Route("{categoryID}/{LocalizationID}")]
        public async Task<IActionResult> GetStoresByCategoryAndByLocation(string categoryID, string localizationID, 
            [FromQuery] PaginationFilter filter )
        {
            PaginationFilter validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            String date = string.Empty;
            if (string.IsNullOrEmpty(categoryID))
                date = "Date";
            var stores = await _storeService.GetStores(categoryID, localizationID, date);

            var paginatedStores = stores
                                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize).AsQueryable();
                            
            //var result = PaginatedList<StoreDto>.CreateAsync(stores.AsQueryable(), pageNumber, pageSize);

            if (paginatedStores != null)
                return Ok(new PagedResponse<IEnumerable<StoreDto>>(paginatedStores, validFilter.PageNumber, validFilter.PageSize));
            return NotFound();
        }
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetStoreCategories()
        {
            var storeCategories = await _storeService.GetStoreCategoriesAsync();
            if (storeCategories != null)
                return Ok(storeCategories);
            return BadRequest();
        }
        [HttpGet]
        [Route("{Id}/category/{products}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(string storeId)
        {
            var products = await _productService.GetProductsByCategoryId(storeId);
            if (products == null)
                throw new NullReferenceException();
            else
                return Ok(products);
        }
        [HttpGet]
        [Route("products/{storeId}")]
        public async Task<IActionResult> GetProductsAsync(string storeId)
        {
            
            var products = await _productService.GetProductsByStore(storeId);
            if (products == null)
                throw new NullReferenceException();
            else
                return Ok(products);
        }
        //[HttpGet]
        //[Route("{products}/{categories}")]
        //public async Task<IActionResult> GetProducts(string storeId)
        //{
        //    var products = await _productService.GetProductsByStore(storeId);
        //    if (products == null)
        //        throw new NullReferenceException();
        //    else
        //        return Ok(products);
        //}
        [HttpGet]
        [Route("{categoryId}/{pageNumber}/{limitPerPage}")]
        //[Route("categoryId?limit=10&offSet=4")]
        public async Task<IActionResult> GetStoresByCategoryIdAsync(int? categoryId, int pageNumber, int limitPerPage)
        {
            limitPerPage = 10;
            if (categoryId == null)
                return NotFound();
            else
            {
                var stores = await ((Task<IEnumerable<StoreDto>>)_storeService
                    .GetStoresByCategoryIdAsync((int)categoryId, pageNumber, limitPerPage));
                return Ok(stores);
            }
        }
        #endregion read

        #region PUT update
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
                catId = category.storeCategoryName;
                _storeService.UpdateStoreCategory(catId.ToString(), category);
                return Ok(category);
            }
        }
        
        #endregion update

        #region DELETE delete
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
                _storeService.DeleteStoreCategory(categoryId);
                return Ok(true);
            }
        }
        #endregion   delete
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