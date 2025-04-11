
//using allopromo.Core.Application.Dto;

using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface ILocalisationService: IDisposable
    {
        Task<bool> CreateAsync(tCity city);
        Task<tCity> GetCityByName(string Name);
        Task<tCity> Get(string cityId);
        Task<IEnumerable<CityDto>> GetCities();
        Task <string> GetUserCurrentCity(string ip);
        void Update(tCity aisle);
        void Delete(tCity aisle);
    }
}