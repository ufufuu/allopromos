﻿using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Entities
{
    
        public class Location
        {
            public int localizationId { get; set; }

            public string GpsCoordinates { get; set; }

            public string GpsLongitude { get; set; }

            public string GpsLatitude { get; set; }

            public string Adress { get; set; }
        }
}
