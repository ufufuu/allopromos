
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface ILocationService
    {
        Task<bool> CreateAsync(City city);
        Task<City> GetCityByName(string Name);
        Task<City> Get(string cityId);
        Task<IEnumerable<City>> GetCities();
        Task <string> GetUserCurrentCity(string ip);
        void Update(City aisle);
        void Delete(City aisle);
    }
}