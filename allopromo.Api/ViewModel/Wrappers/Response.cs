using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model.Wrappers
{
    public class Response<T>
    {
        public T _data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public Response(T data)
        {
            Succeeded = true;
            Errors = null;
            Message = String.Empty;
            _data = data;
        }
    }
}
