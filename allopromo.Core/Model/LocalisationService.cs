using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Contracts
{
    public class LocalisationService: ILocalisationService//, IDisposable
    {
        private IRepository<tCity> _cityRepository { get; set;}
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
        public async Task<bool> CreateAsync(CityDto cityDto)
        {
            tCity city = new tCity();
            //city.cityId = 324;
            city.cityName = cityDto.cityName;
            var country = (from q in _countryRepository.GetAllAsync().Result.AsQueryable()
                          .Where(x=>x.countryName.ToString()=="Togo") select q).FirstOrDefault();
            city.cityCountry = country;
            city.cityGpsLatitude = string.Empty;
            city.cityGpsLongitude = string.Empty;
            _cityRepository.Add(city);
            //_cityRepository.Save();
            return true;
        }
       
        public Task<bool> CreateAisle(AisleDto aisle)
        {
            return null;
        }
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

        public Task<string> GetAisle(AisleDto aisles)
        {
            return null;
        }
        public List<AisleDto> GetAisles()
        {
            var ailesRepository = new List<allopromo.Core.Entities.tAisle>();
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Boucherie" });
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Charcuterie" });
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Boulangerie" });
            //return TConvertor.ConverToListObj((ailesRepository)) as List<AisleDto>;
            return null;
        }
        #endregion

        #region Update
        public void Put(CityDto aisle)
        {
            throw new NotImplementedException();
        }
        public void Put(AisleDto aisle)
        {
        }
        public void UpdateAisle(AisleDto aisle)
        {
        }
        #endregion

        #region Delete
        public void Delete(CityDto city)
        {
            _cityRepository.Delete(city);
        }
        public void DeleteAisle(AisleDto aisle)
        {
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
}
