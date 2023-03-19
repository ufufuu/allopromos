using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException():base()
        { }
    }
}
