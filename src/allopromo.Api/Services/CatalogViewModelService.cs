using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Services
{
    public class CatalogIndexViewModel
    {

    }
    public interface ICatalogViewModelService
    {
        Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex,
            int itemsPage,
            int? brandId,
            int? typeId);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
    public class CatalogViewModelService : ICatalogViewModelService
    {
        public Task<IEnumerable<SelectListItem>> GetBrand()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogIndexViewModel> GetCatalogItem(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
    public class SelectListItem
    {

    }
}
