using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Shared.Exceptions
{
    public class HttpErrorException:Exception
    {
        public int statusCode { get; set; }
        public string errorMessage { get; set; }
        public HttpErrorException()
        {

        }
    }
}
