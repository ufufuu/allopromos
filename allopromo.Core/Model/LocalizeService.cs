using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Contracts
{
    public class LocalizeService: ILocalizeService
    {
        private allopromo.Core.Abstract.IRepository<tCity> _cityRepository { get; set;}
        public LocalizeService(allopromo.Core.Abstract.IRepository<tCity> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<bool> Create(CityDto cityDto)
        {
            tCity city = new tCity();
            city.cityName = cityDto.cityName.ToString();
            city.countryId = 2344;
            city.cityId = 4433;

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
        public List<CityDto> Gets()
        {
            var ailesRepository = new List<allopromo.Core.Entities.tAisle>();
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Boucherie" });
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Charcuterie" });
            ailesRepository.Add(new Entities.tAisle { tAisleId = new Guid(), tAisleName = "Boulangerie" });

            return null;
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
