using allopromo.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Abstract
{
    public interface IAisleService
    {
        Task<bool> CreateAisle(AisleDto aisle); // ? Task CreateUser(
        Task<string> GetAisle(AisleDto aisles);
        public List<AisleDto> GetAisles();
        public void DeleteAisle(AisleDto aisle);
        public void UpdateAisle(AisleDto aisle);
    }
}