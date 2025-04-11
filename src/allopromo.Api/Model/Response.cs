using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model
{
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string jwtToken { get; set; }
    }
}
