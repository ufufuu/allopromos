
using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Core.Model
{
    public class VendorService: IVendorService
    {
        private readonly IRepository<Vendor> _vendorRepo; 
        public async Task<Vendor> GetVendor(string Id)
        {
            return await _vendorRepo.GetByIdAsync(Id);
        }

        //public IAppDbContext<TEntity> db { get; set; }

        public async Task<IEnumerable<Vendor>> GetVendors ( )
        {
            return  await _vendorRepo.GetAllAsync();
        }
    }
}

