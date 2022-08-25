using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace allopromo.SuperAdmin.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private HttpClient httpClient;
        [HttpGet]
        public void OnGet()
        {

        }
        [HttpPost]
        public void OnPost()
        {
            //Request.res

        }
    }
}
