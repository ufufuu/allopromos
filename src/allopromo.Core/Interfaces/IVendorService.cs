using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetVendors();
        Task<Vendor> GetVendor(string Id);
    }
}
