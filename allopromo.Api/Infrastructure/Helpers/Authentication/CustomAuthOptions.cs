using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Helpers.Authentication
{
    public class CustomAuthOptions:AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "cusom auth";
        public string Scheme => DefaultScheme;
        public StringValues AuthKey { get; set; }
    }
}
