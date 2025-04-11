using System;
using System.Collections.Generic;
using System.Text;
using allopromo.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using allopromo.Core.Abstract;
using AutoMapper;
using allopromo.Core.Entities.Domain;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;

namespace allopromo.Core.Services
{
    public interface ILocationService34
    {
        
    }
    public class LocationService : ILocationService, IDisposable
    {
        private static string urlCityURL = "http://ipinfo.io/";

        private IRepository<City> _cityRepository { get; set; }

        private IRepository<Country> _countryRepository { get; set; }

        public IMapper _mapper { get; set; }

        public LocationService(
          IRepository<City> cityRepository,
          IRepository<Country> countryRepository,
          IMapper mapper)
        {
            this._cityRepository = cityRepository;
            this._countryRepository = countryRepository;
            this._mapper = mapper;
        }

        public LocationService()
        {
        }

        public async Task<bool> CreateAsync(City cityDto)
        {
            City city = new City();
            city.cityName = cityDto.cityName;

            //ParameterExpression parameterExpression;
            // ISSUE: method reference

            var country = this._countryRepository.GetAllAsync().Result.AsQueryable<Country>();
                

            city.cityCountry = country.FirstOrDefault();
            this._cityRepository.Add(city);
            return true;
        }

        public async Task<City> GetCity(string cityId)
        {
            return await this._cityRepository.GetByIdAsync(cityId);
        }

        public async Task<City> GetCityByName(string cityName)
        {
            var cityByName = (await this._cityRepository.GetAllAsync())
                .AsQueryable()
                .Where(x => x.cityName == cityName);

            return cityByName.FirstOrDefault();
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return this._mapper.Map<IEnumerable<City>>((object)await this._cityRepository.GetAllAsync()) ?? throw new NullReferenceException();
        }

        public async Task<string> GetUserCurrentCity(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string str = new WebClient().DownloadString(""+urlCityURL + ip);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(str);
                RegionInfo regionInfo = new RegionInfo(ipInfo.Country);
                ipInfo.Country = regionInfo.EnglishName;
            }
            catch (Exception ex)
            {
                ipInfo.Country = (string)null;
            }
            return await Task.FromResult<string>(ipInfo.City);
        }

        public void Update(City aisle) => throw new NotImplementedException();

        public void Delete(City city) => this._cityRepository.Delete(city);

        public Task<City> Get(string cityId) => throw new NotImplementedException();

        public void Dispose()
        {
        }
    }
}

