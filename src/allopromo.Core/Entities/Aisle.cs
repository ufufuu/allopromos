using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Entities
{
    public class Aisle
    {
        public Guid tAisleId { get; set; }
        public string tAisleName { get; set; }
        public bool tAisleIsParent { get; set; }
    }
}
