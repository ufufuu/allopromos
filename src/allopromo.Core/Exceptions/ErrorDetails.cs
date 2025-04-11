using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace allopromo.Core.Exceptions
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string errorMessage { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
