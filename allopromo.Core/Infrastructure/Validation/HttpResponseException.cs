using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Model.Validation
{
    public class HttpResponseException:Exception
    {
        public int statusCode { get; set; } = 400;
        public object _message { get; set; }
        public HttpResponseException(string message)
        {
            _message = message;
        }
    }
}
