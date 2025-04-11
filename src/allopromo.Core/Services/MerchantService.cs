using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allopromo.Core.Entities;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using allopromo.Core.Domain;
using AutoMapper;
using System.Linq;
using allopromo.Core.Services;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace allopromo.Core.Services
{   
    public class MerchantService : IMerchantService
    {
        public event StoreCreatedEventHandler storeCreated;


        #region Constantes
        public HttpClient _httpClient { get; set; }//https://cdn.pixabay.com/photo/2013/10/15/09/12/flower-195893_150.jpg
        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        #endregion


        #region Properties

        //public event StoreCreatedEventHandler StoreCreated;

        public Action<string> _StoreCreated;
        public IMembershipService _accountService { get; set; }
        public IUserService _userService { get; set; }

        public UserManager<IdentityUser> _userManager { get; set; }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        #endregion

        public IDepartmentService _departmentService { get;set; }
        public IRepository<Department> _departmentRepository { get; set; }

        public UserManager<ApplicationUser> userManager { get; set; }
        public IRepository<StoreCategory> _categoryRepository { get; set; }


        #region Fields
        private IProductService _productService { get; set; }

        //private IRepository<tStore> StoreRepository;
        private ILocalisationService _localisationService { get; set; }
        public INotifyService _notificationService { get; set; }

        #endregion


        #region Events
        
        #endregion


        #region Creating Objects 
        
        public Task<Store> CreateStore(Store store)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Public Methods
        public Task<bool> UserBecomesVendor()
        {
            return Task.FromResult(true);
        }
        #endregion
    }

    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}
}

/* 1. table jointure
 * 2. re architecture
 * 3. I QUery Patterns
 */
// ? Builder !
/*
* MapBox token: pk.eyJ1IjoiYWxpd2l5YW8iLCJhIjoiY2twaXo5bnVvMHYzNTJucGUzbTE3NXRodSJ9.qGOJOXU4ys9x_LU9Arj_MA
*/
//https://api.mapbox.com/geocoding/v5/{endpoint}/{

//IQuery Pattern ?
/* particulier a particulier : entreprises
 * Latitude: 46.861114 / N 46° 51' 40.012''
Longitude: -71.268900 / W 71° 16' 8.04''
*/
/*
 * https://www.gps-coordinates.net/api
 */