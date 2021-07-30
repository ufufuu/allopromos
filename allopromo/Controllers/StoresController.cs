using allopromo.Model.DTO;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public List<StoreDTO> GetStores()
        {
            return new StoreDTOConverter().ConvertToStoreDTO(_storeService.GetStores().ToList());
        }
        [HttpGet]
        [Route("api/stores/{Id}")]
        public StoreDTO GetStore(string storeId)
        {
            return new StoreDTOConverter().ConvertToStoreDTO(_storeService.GetStore(storeId));
        }
        [HttpPost]
        //[Route("api/store/create")]
        public void CreateStore(Store store)
        {
            //return new StoreDTOConverter().ConvertToStoreDTO(_storeService.CreateStore(store));
            _storeService.CreateStore(store);
        }
    }
}
/*
 * 1 -- Account Asp.net Identity + fb+ tiwtter !
 * 2-- create store scenario <- account login and register
 * business Login for Account registration
 * 3- Test Unit for bl account Registration             3-- Code Versionning    4
 * 4 - TDD / Buzz Fizz
 * Reapeat !
 * 
 */