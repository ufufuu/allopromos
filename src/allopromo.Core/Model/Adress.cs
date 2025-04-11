﻿using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string road { get; set; }

        [DataMember]
        public string suburb { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string state_district { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public string postcode { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string country_code { get; set; }
    }
}

