using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Admin.Models.Dto
{
    public class StoreDto
    {
        public string storeId { get; set; }
        public int storeNumber { get; set; }
        public string storeName{ get; set; }
        public StoreCategoryDto storeCategory { get; set; }
        public StoreStatus storeStatus { get; set; } 
    }
    public enum StoreStatus
    {
        Created=0,
        Awaiting=1,
        Activated=9,
        Disabled=-1
    }
}
