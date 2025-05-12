using allopromo.Core.Abstract;
using allopromo.Core.Entities;
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
    public interface ILocalizationService
    {
    }
    public class LocalizationService : ILocalizationService
    {
        private IRepository<City> _cityRepository { get; set; }
        private IRepository<Country> _countryRepository { get; set; }

        #region Constructors
        public LocalizationService(IRepository<City> cityRepository, IRepository<Country> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
        public LocalizationService()
        { }
        #endregion

        #region Methods
        public async Task<City> GetCity(string cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            return city;
        }
        public async Task<City> GetCityByName(string Name)
        {
            var city = (await _cityRepository.GetAllAsync()).AsQueryable()
                .Where(x => x.cityName.ToString() == "Kara").FirstOrDefault();
            return city;
        }
        public void Update(City aisle)
        {
            throw new NotImplementedException();
        }
        public void Delete(City city)
        {
            _cityRepository.Delete(city);
        }

        public Task<City> Get(string cityId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}