using allopromo.Core.Abstract;
using allopromo.Core.Aggregates;
using allopromo.Core.Application.Dto;
//using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Services
{
    public class LocalisationService : ILocalisationService//, IDisposable
    {
        private IRepository<tCity> _cityRepository { get; set; }
        private IRepository<tCountry> _countryRepository { get; set; }
        private static string urlCityURL = "http://ipinfo.io/";

        #region Constructors
        public LocalisationService(IRepository<tCity> cityRepository, IRepository<tCountry> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
        public LocalisationService()
        { }
        #endregion

        #region CREATE
        public async Task<bool> CreateAsync(tCity cityDto)
        {
            tCity city = new tCity();
            //city.cityId = 324;
            city.cityName = cityDto.cityName;
            var country = (from q in _countryRepository.GetAllAsync().Result.AsQueryable()
                          .Where(x => x.countryName.ToString() == "Togo")
                           select q).FirstOrDefault();
            city.cityCountry = country;
            city.cityGpsLatitude = string.Empty;
            city.cityGpsLongitude = string.Empty;
            _cityRepository.Add(city);
            //_cityRepository.Save();
            return true;
        }

        //public Task<bool> CreateAisle(AisleDto aisle)
        //{
        //    return null;
        //}
        #endregion

        #region READ
        public async Task<tCity> GetCity(string cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            return city;
        }
        public async Task<tCity> GetCityByName(string Name)
        {
            var city = (await _cityRepository.GetAllAsync()).AsQueryable()
                .Where(x => x.cityName.ToString() == "Kara").FirstOrDefault();
            return city;
        }
        public async Task<IEnumerable<CityDto>> GetCities()
        {
            var tObjs = await _cityRepository.GetAllAsync();
            IEnumerable<CityDto> cities = AutoMapper.Mapper.Map<IEnumerable<CityDto>>(tObjs);
            if (cities != null)
                return cities;
            else
                throw new NullReferenceException();
        }
        public async Task<string> GetUserCurrentCity(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString(urlCityURL + ip);
                System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage();

                System.Net.Http.HttpResponseMessage responseMessage = new System.Net.Http.HttpResponseMessage();


                //string info2 = new System.Net.Http.HttpClient().SendAsync(requestMessage, urlCityURL + ip);

                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRIf = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRIf.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }
            return await Task.FromResult(ipInfo.City);
        }

        #endregion

        #region Update
        public void Update(tCity aisle)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete
        public void Delete(tCity city)
        {
            _cityRepository.Delete(city);
        }

        public Task<tCity> Get(string cityId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Specific Methods

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
        #endregion
    }

    public class StoreLocator
    {
        HttpClient _httpClient { get; set; }
        private ILogger _logger { get; set; }
        public StoreLocator(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public string GetLocation()
        {
            var location = getAddress(23.5270797, 77.2548046);
            return location.ToString();
        }
        private string ReturnGPSCoordinates()
        {
            var rootObjc = getAddress(23.5270797, 77.2548046);
            return ""; //rootObj.display_Name;
        }
        private static RootObject getAddress(double Longitude, double Latitude)

        //getAddress(23.5270797, 77.2548046);
        {
            //onst double longitude = Longitude;
            //const double latitude = Latitude;

            //const string pathUrl = " https://nominatim.openstreetmap.org/reverse?format=json&lat=30.4573699&lon=-97.8247654";

            //const string  mapBox= " https://api.mapbox.com/geocoding/v5/{endpoint}/";

            const string reverseGeoCodingApiEndPoint = " http://nominatim.openstreetmap.org/reverse?format=json&lat= "; // + Latitude + "&lon=" + Longitude;

            HttpResponseMessage msg = new HttpResponseMessage();
            RootObject obj = null;
            using (var httpClient = new HttpClient())
            {
                //msg = await httpClient.GetFromJsonAsync(pathUrl);
            }
            using (var webClient = new WebClient())
            {
                var jsonData = webClient.DownloadData(reverseGeoCodingApiEndPoint);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
                obj = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
            }
            return obj;
        }
    }
}