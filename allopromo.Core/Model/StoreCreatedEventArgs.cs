using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Core.Model
{
    public class StoreCreatedEventArgs : EventArgs
    {
        //public string storeName { get; set; }


        public Application.Dto.StoreDto store { get; set; }
    }
    public class StoreCreatedEventArgsSSS
    {
        public HashSet<tStore> Stores { get; set; }
    }
}
