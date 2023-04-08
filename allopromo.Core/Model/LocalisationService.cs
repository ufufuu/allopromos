using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Contracts
{
    public class LocalisationService: ILocalisationService
    {
        private IRepository<tCity> _cityRepository { get; set;}
        private static string urlCityURL = "http://ipinfo.io/";
        public LocalisationService(IRepository<tCity> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<bool> Create(CityDto cityDto)
        {
            tCity city = new tCity();
            city.cityId = 324;
            city.cityName = cityDto.cityName;
            city.cityCountry = new tCountry { countryName = "togo" };
            city.cityGpsLatitude = string.Empty;
            city.cityGpsLongitude = string.Empty;
            _cityRepository.Add(city);
            _cityRepository.Save();
            return true;
        }
        public void Delete(CityDto city)
        {
            _cityRepository.Delete(city);
        }
        public async Task<tCity> Get(string cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            return city;
        }
        public async Task<IEnumerable<CityDto>> GetCities()
        {
           var tObjs =await _cityRepository.GetAllAsync();
           IEnumerable<CityDto> cities = AutoMapper.Mapper.Map<IEnumerable<CityDto>>(tObjs);
           if(cities !=null)
                return cities;
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
                ipInfo.Country=null;
            }
            return await Task.FromResult(ipInfo.City);
        }
        public void Put(AisleDto aisle)
        {
        }
        public Task<bool> CreateAisle(AisleDto aisle)
        {
            return null;
        }
        public void DeleteAisle(AisleDto aisle)
        {
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
        public void UpdateAisle(AisleDto aisle)
        {
        }
        public void Put(CityDto aisle)
        {
            throw new NotImplementedException();
        }
    }
}
