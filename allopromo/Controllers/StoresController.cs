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
    //[Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private IStoreService _storeService { get; set; } // What would read-only change here vs private ?
        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        [Route("api/stores")]
        public List<StoreDTO> GetStores()
        {
            var stores= new StoreDTOConverter().ConvertToStoreDTO(_storeService.GetStores().ToList());
            //return new StoreDTOConverter().ConvertToStoreDTO(_storeService.GetStores().ToList());
            int v = 4;
            return stores;
        }
        [HttpGet]
        [Route("api/stores/{Id}")]
        public StoreDTO GetStore(string Id)
        {
            return new StoreDTOConverter().ConvertToStoreDTO(_storeService.GetStore(Id));
        }
        [HttpPost]
        [Route("api/store/create")]
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