
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
    public class LocationService : ILocationService, IDisposable
    {
        private static string urlCityURL = "http://ipinfo.io/";
        private IRepository<City> _citiesRepository { get; set; }
        private IRepository<Country> _countryRepository { get; set; }
        public IMapper _mapper { get; set; }
        public LocationService(
          IRepository<City> citiesRepository,
          IRepository<Country> countryRepository,
          IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
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

            var country = this._countryRepository.GetAllAsync()
                .Result.AsQueryable<Country>();

            city.cityCountry = country.FirstOrDefault();
            this._citiesRepository.Add(city);
            return true;
        }

        public async Task<City> GetCity(string cityId)
        {
            return await this._citiesRepository.GetByIdAsync(cityId);
        }

        public async Task<City> GetCityByName(string cityName)
        {
            var cityByName = (await this._citiesRepository.GetAllAsync())
                .AsQueryable()
                .Where(x => x.cityName == cityName);
            return cityByName.FirstOrDefault();
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return this._mapper.Map<IEnumerable<City>>(await this._citiesRepository.GetAllAsync()) 
                ?? throw new NullReferenceException();
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
        public void Delete(City city) => this._citiesRepository.Delete(city);
        public Task<City> Get(string cityId) => throw new NotImplementedException();
        public void Dispose()
        {
        }
    }
}

