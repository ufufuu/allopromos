using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.ValueObjects
{
    public class Address
    {
        public string StreetNumber  { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
