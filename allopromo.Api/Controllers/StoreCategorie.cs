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
    public delegate bool SStoreCreatedEventHandler (object source, EventArgs e);
    [Route("api/[controller]")]
    [ApiController]
    public class StoreSCategories : ControllerBase
    {
        //public event StoreCreatedEventHandler StoreCreated; 
        //, IConfiguration config
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        private INotifyService _notificationService; // { get; set; }
        private IProductService _productService;
        //public StoreCreatedEventArgs storeCreated { get; set; }
        //public event EventHandler<string> _storeCreated;
        private IStoreQuery _storeQuery;
        public StoreSCategories(IStoreService storeService,
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
    }
}
/*
 * https://www.c-sharpcorner.com/article/learn-about-web-api-validation/
 * Number of occurence in a Word , number of words in a Phrase !
 */