using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IMerchantService
    {
        public Task<bool> UserBecomesVendor();
    }
}