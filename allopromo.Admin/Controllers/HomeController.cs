using allopromo.Admin.Models.ViewModel;
using allopromo.Administration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using allopromo.Shared;
namespace allopromo.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private IHttpClientFactory _httpClientFactory;
        private string Create_User_Api_Url = Constantes.ApiInfo.apiUrl;
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Models.Dto.CategoryDto> categories = new List<Models.Dto.CategoryDto>();
            return View(categories.AsEnumerable());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            List<Models.Dto.CategoryDto> categories = new List<Models.Dto.CategoryDto>();
            categories.Add(new Models.Dto.CategoryDto { categoryId = 1, categoryName = "Xsds", catThumbnail = "" });
            categories.Add(new Models.Dto.CategoryDto { categoryId = 1, categoryName = "Xsds", catThumbnail = "" });
            categories.Add(new Models.Dto.CategoryDto { categoryId = 1, categoryName = "Xsds", catThumbnail = "" });
            var cats = categories.AsEnumerable();
            return View(cats);

            //Response.Redirect("Account/Login");
            /*
            if (loginViewModel == null)
                return NoContent();
            using (var httpClient = new HttpClient())
            {
                Core.Application.Dto.UserDto login1 = null;
                try
                {
                    var response = string.Empty;
                    string json = JsonConvert.SerializeObject(loginViewModel);
                    StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    //var content = new HttpContent();
                    var client = httpClientFactory.CreateClient(Create_User_Api_Url);
                    HttpResponseMessage responseMsg = client.PostAsync("https://localhost:44367/api/v1/User/Login",
                        httpContent).Result;
                    if (responseMsg.IsSuccessStatusCode)
                    {
                        response = responseMsg.StatusCode.ToString();
                    }
                    var login = JsonConvert.DeserializeObject<Core.Application.Dto.UserDto>(response.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return View(login1);
            }*/
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
