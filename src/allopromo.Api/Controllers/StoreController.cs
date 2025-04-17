using allopromo.Core.Model;
using allopromo.Api.DTOs;
using allopromo.Api.Model.Filter;
using allopromo.Api.Model.ViewModel.Page;
using allopromo.Api.Model.Wrappers;
using allopromo.Core.Abstract;
using allopromo.Core.Domain;
using allopromo.Core.Entities;
using allopromo.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Interfaces;

#nullable enable
namespace allopromo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoreController : ControllerBase
    {
        public const int pageSize = 2;
        private readonly IStoreService _storeService;
        //private readonly ICatalogService _catalogService;
        private readonly INotifyService _notificationService; 
        private readonly allopromo.Core.Interfaces.ICatalogService _catalogService;
        public int pageNumber { get; set; }
        public IUserService _userService { get; set; }
        public IImageUploadService _imageUploadService { get; set; }
        public IMediaService _mediaService { get; set; }
        public HttpContextAccessor _httpContextAccessor { get; set; }
        private readonly MediatR.IMediator _mediator; 
        private IMapper _mapper;
        public StoreController(
          IStoreService storeService,
          ICatalogService productService,
          allopromo.Core.Interfaces.ICatalogService catalogService,
          IUserService userService,
          IImageUploadService imageUploadService,
          IMediaService mediaService,
          INotifyService notificationService,
          HttpContextAccessor httpContextAccessor,
          IMapper mapper)
        {
            _userService = userService;
            _storeService = storeService;
            //_productService = productService;
            _catalogService = catalogService;
            _notificationService = notificationService;
            _imageUploadService = imageUploadService;
            _mediaService = mediaService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            
        }

        [HttpPost]
        [Route("create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PostStore([FromForm] CreateStoreDto dto)
        {
            if (dto == null)
                return BadRequest();

            var fdf = await _mediaService.SaveImages(dto.storeFiles);
            string str = await _imageUploadService.SaveImages(dto.storeFiles);

            var currentUser = await _userService.GetCurrentUser();
            dto.ProprioName = currentUser.UserName;
            string categoryName = dto.CategoryName;

            var category = await _catalogService.GetStoreCategory(dto.CategoryName);

            string city = dto.City;
            Store store = _mapper.Map<Store>(dto);
            
            store.storeName = dto.StoreName;
            store.storeDescription = dto.StoreDescription;
            store.User = currentUser;
            store.Category = category;

            //model = await _mediator.Send(new AddCategoryCommand() { Model = model });
            await _storeService.CreateStoreAsync(store, currentUser.UserName, city, dto.CategoryName);

            if(await _userService.UpdateUserRole("Merchants", currentUser.UserName))
                return Ok(dto);

            return Ok((object)new allopromo.Api.Model.Response()
            {
                Status = "400",
                Message = "User Already Has A Store "
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetStores([FromQuery] PaginationFilter filter)
        {
            StoreController storeController = this;
            PaginationFilter validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            IEnumerable<Store> storesAsync = await storeController._storeService.GetStoresAsync();
            IEnumerable<StoreDto> source = storeController._mapper.Map<IEnumerable<StoreDto>>((object)storesAsync);
            IQueryable<StoreDto> queryable = source.Skip<StoreDto>((validFilter.PageNumber - 1) * validFilter.PageSize).Take<StoreDto>(validFilter.PageSize).AsQueryable<StoreDto>();

            //PaginatedList<StoreDto>.CreateAsync(source.AsQueryable<StoreDto>(), storeController.pageNumber, 2);
            //var stores = source != null ? (ActionResult)storeController.Ok((object)queryable) 
              //  : (ActionResult)storeController.NotFound();
            //validFilter = (PaginationFilter)null;

            return Ok(queryable);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetStore(string Id)
        {
            StoreController storeController = this;
            if (Id == null)
                return (IActionResult)storeController.BadRequest();
            Store storeByIdAsync = await storeController._storeService.GetStoreByIdAsync(Id);
            return storeByIdAsync != null ? (IActionResult)storeController.Ok((object)storeByIdAsync) : (IActionResult)storeController.NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("{userName}")]
        public async Task<IActionResult> GetStoresByUser(string userName)
        {
            StoreController storeController = this;
            if (userName == null)
                return (IActionResult)storeController.BadRequest();
            IQueryable<Store> storesByUserName = await storeController._storeService.GetStoresByUserName(userName);
            return storesByUserName != null ? (IActionResult)storeController.Ok((object)storesByUserName) : (IActionResult)storeController.NotFound();
        }

        [HttpGet]
        [Route("{LocalizationId}")]
        public async Task<IActionResult> GetStoresByCategoryAndByLocation(
          string categoryId,
          string localizationId,
          [FromQuery] PaginationFilter filter)
        {
            StoreController storeController = this;
            PaginationFilter validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            string sortingOrder = string.Empty;
            if (string.IsNullOrEmpty(categoryId))
                sortingOrder = "Date";
            IEnumerable<Store> stores = await storeController._storeService.GetStores(categoryId, localizationId, sortingOrder);
            IEnumerable<StoreDto> data = storeController._mapper.Map<IEnumerable<StoreDto>>((object)stores.Skip<Store>((validFilter.PageNumber - 1) * validFilter.PageSize).Take<Store>(validFilter.PageSize).AsQueryable<Store>());
            IActionResult categoryAndByLocation = data == null ? (IActionResult)storeController.NotFound() : (IActionResult)storeController.Ok((object)new PagedResponse<IEnumerable<StoreDto>>(data, validFilter.PageNumber, validFilter.PageSize));
            validFilter = (PaginationFilter)null;
            return categoryAndByLocation;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetStoreCategories()
        {
            StoreController storeController = this;
            IEnumerable<StoreCategory> storeCategoriesAsync = await storeController._storeService.GetStoreCategoriesAsync();
            return storeCategoriesAsync == null ? (IActionResult)storeController.BadRequest() : (IActionResult)storeController.Ok((object)storeCategoriesAsync);
        }

        [HttpGet]
        [Route("{categoryName}/{pageNumber}/{limitPerPage}")]
        public async Task<IActionResult> GetStoresByCategory(
          string categoryName,
          int pageNumber,
          int pageSize)
        {
            StoreController storeController = this;
            if (categoryName == null)
                return (IActionResult)storeController.NotFound();
            IEnumerable<Store> source = (await storeController._storeService.GetStoresByCategoryNameAsync(categoryName, pageNumber, pageSize)).Skip<Store>((pageNumber - 1) * pageSize).Take<Store>(pageSize);
            IEnumerable<StoreDto> storeDtos = storeController._mapper.Map<IEnumerable<StoreDto>>((object)source);
            return (IActionResult)storeController.Ok((object)storeDtos);
        }

        [HttpPut]
        [Route("{storeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Merchants")]
        public ActionResult PutStore(string storeId, [FromBody] StoreCategoryDto storeCategoryDto)
        {
            return (ActionResult)this.Ok();
        }

        [HttpPut]
        [Route("{storeCategoryId}")]
        public ActionResult PutStoreCategory([FromBody] StoreCategoryDto storeCategoryDto)
        {
            string str = string.Empty;
            if (storeCategoryDto == null)
                return NotFound();
            str = storeCategoryDto.storeCategoryName;
            return Ok(_mapper.Map<StoreDto>((object)storeCategoryDto));
        }

        private IActionResult PostImage([FromForm] string location) //=> (IActionResult)null;
        {
            return Ok();
        }
        public delegate string mydelegate(string msg);

        public delegate string myGenericDelegate<T>(string msg);
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