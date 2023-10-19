using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IVendorService
    {
        public Task<bool> UserBecomesVendor();
    }
}