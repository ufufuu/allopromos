using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface ILocalizeService
    {
        Task<bool> Create(Application.Dto.CityDto aisle);
        void Delete(CityDto aisle);
        Task<tCity> Get(string cityId);
        List<CityDto> GetCities();
        void Put(CityDto aisle);
    }
}