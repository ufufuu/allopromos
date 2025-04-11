using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Model.Validation
{
    public class HttpResponseException : Exception
    {
        public int statusCode { get; set; } = 400;

        public object _message { get; set; }

        public HttpResponseException(string message) => this._message = (object)message;
    }
}
