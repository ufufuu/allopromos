using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Helpers
{
    public static class CookiesHelper
    {
        public static void SetCookie(string cookieName, string cookieValue, HttpResponse httpResponse)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpResponse.Cookies.Append(cookieName, cookieValue, cookie);       

        }
        public static bool ReadCookie(HttpRequest request)
        {
            var httpRequest = request.Cookies.ContainsKey("k");
            var cookieExist= request.Cookies["user"];
            if (cookieExist!= null)
                return true;
            return false;
        }
    }
}
