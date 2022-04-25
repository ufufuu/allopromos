using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Helpers.Convertors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Contracts
{
    public class AisleService : IAisleService
    {
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
            return TConvertor.ConverToListObj((ailesRepository)) as List<AisleDto>;
        }
        public void UpdateAisle(AisleDto aisle)
        {
        }
    }
}
