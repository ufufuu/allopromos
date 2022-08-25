using allopromo.Admin.Helpers;
using allopromo.Admin.Models;
using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Admin.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Route("Manage/[controller]")]
    public class HomeController : Controller
    {
        string requestBaseUri = "https://localhost:44367/api/";
        string requestUri = "/user/";
        private readonly ILogger<HomeController> _logger;
        private IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClientFactory = httpClientFactory; //cOral1eeLisab7h
            _logger = logger;
        }
        [HttpPut]
        public async Task<IActionResult> Index()
        {
            var cookie = false;
            if (cookie)
            {
                ViewData["userName"] = "kevin Ali";
                var user = ViewData["userName"];
                return View(user);
            }
            else
            {
                return View("Login");//return View or Execute Action ?
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> Index(IEnumerable<LoginViewModel> loginViewModel)
        //{
        //    IEnumerable<LoginViewModel> users = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri(requestBaseUri);
        //        var requestUrl = "user";
        //        var responseMessage = await httpClient.GetAsync(requestUrl);
        //        var contentString = await responseMessage.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<IEnumerable<LoginViewModel>>(contentString);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            users = result;
        //        }
        //    }
        //    return View(users);
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{RequestId = Activity.Current?.Id??HttpContext.TraceIdentifier });
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            HttpResponseMessage responseMessage = null;
            var jsonObj = JsonConvert.SerializeObject(loginViewModel);
            var stringContent = new StringContent(jsonObj,  UnicodeEncoding.UTF8, "application/json");
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (loginViewModel != null)
            {
                using //(var httpClient = _httpClientFactory.CreateClient())//? HttpClientHandler :( (:
                    (var httpClient = new HttpClient())
                {
                   httpClient.BaseAddress = new Uri("https://localhost:44367/api/");
                   var requestUri = "user/login";
                   responseMessage = httpClient.PostAsync(requestUri, stringContent
                                  ).Result;
                   var loginPost = httpClient.PostAsJsonAsync<LoginViewModel>("user/login", loginViewModel);
                   loginPost.Wait();
                   responseMessage = loginPost.Result;
                   var contentResponse = await responseMessage.Content.ReadAsStringAsync();
                   var result = JsonConvert.DeserializeObject<LoginViewModel>(contentResponse);
                    if (responseMessage.IsSuccessStatusCode)
                   {
                        CookiesHelper.SetCookie(loginViewModel.UserName, loginViewModel.PasswordHash,
                        this.Response);
                        ViewBag.UserName = loginViewModel.UserName;
                        ViewData["role"] = "admin from Login";

                        //Response.Redirect("Home/Index");
                        //RedirectToAction("Home", "Index");
                        return View("Index", result);
                   }
                    else
                        return View("Login");
                }
            }
            return View(responseMessage);
        }
        //public async Task<IActionResult> Register(UserDto userDto)
        //{
        //    HttpResponseMessage responseMessage = null;
        //    if (userDto != null)
        //    {
        //        using (var httpClient =  _httpClientFactory.CreateClient())
        //        {
        //            HttpResponseMessage responseMsg = await httpClient.GetAsync(requestBaseUri + requestUri);
        //            var responseBody = await responseMsg.Content.ReadAsStringAsync();
        //            var user = new StringContent(userDto.ToString());
        //            responseMessage = await httpClient.PostAsync(requestBaseUri + requestUri, user);
        //        }
        //    }
        //    return View(responseMessage);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Login()
        //{
        //    //if user is Already Logged in, if cookie exists
        //    //then Redirect to Index
        //    var cookie = CookiesHelper.ReadCookie(this.Request);
        //    if (cookie)
        //       // Response.Redirect("Home/Index");
        //    RedirectToAction("Home", "Index");
        //    return View();
        //}
        private bool ReadCookie()
        {
            var cookieExist = CookiesHelper.ReadCookie(this.Request);
            if (cookieExist)
                return true;
            return false;
        }
    }
}