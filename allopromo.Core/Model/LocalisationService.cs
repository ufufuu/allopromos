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
            city.cityName = cityDto.cityName.ToString();
            city.countryId = 2344;

            //city.cityId = 4433;
            await _cityRepository.Add(city);
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
            IEnumerable<CityDto> cities = null;
            cities = AutoMapper.Mapper.Map
                <IEnumerable<CityDto>>(await _cityRepository.GetAllAsync());
            return cities;
        }
        public new async Task<string> GetUserCurrentCity(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString(urlCityURL + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRIf = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRIf.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country=null;
            }
            return ipInfo.City;
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
