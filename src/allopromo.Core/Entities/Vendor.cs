using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Entities
{
    public class Vendor
    {
    }
    public class tMerchant
    {
        public string tMerchantId { get; set; }

        public int tMerchantName { get; set; }

        public virtual int tMerchantCategory { get; set; }
    }
}
