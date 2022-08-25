using allopromo.Admin.EventHandlers;
using allopromo.Admin.Helpers;
using allopromo.Admin.Models;
using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.ViewModel;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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
    public class CategoriesController : Controller, IHttpHandler
    {
        string requestBaseUri = "https://localhost:44367/api";
        private readonly ILogger<CategoriesController> _logger;
        private IHttpClientFactory _httpClientFactory;
        IHttpHandler httpHandler;
        private IValidator<StoreCategoryDto> _storeCategoryValidator;
        private IMapper mapper;
        private IConfiguration config;
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{RequestId = Activity.Current?.Id??HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateStoreCategory(string storeCategoryName)
        {
            if (storeCategoryName ==null)
                return null;
            else
            {
                StoreCategoryDto categoryDto = new StoreCategoryDto();
                categoryDto.storeCategoryName = storeCategoryName;
                if (_storeCategoryValidator != null)
                {
                    var validation = await _storeCategoryValidator?.ValidateAsync(categoryDto);
                    if (!validation.IsValid)
                        return View();
                }
                string requestUrl = "store/categories/create";
                var jsonObj = JsonConvert.SerializeObject(categoryDto);
                var jsonStringObj = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                HttpContent contentResponse = null;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(requestBaseUri);
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUrl, jsonStringObj);
                    {
                        int y = 4;
                        return View(httpResponseMessage);
                    }
                }
            }
        }
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            return View("CreateStoreCategory");
        }
        public async Task<IActionResult> SendAsync()
        {
            return null;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (int? categoryId)
        {

            if (categoryId == null)
                return NotFound();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestBaseUri);
                var requestUrl = "store/categories/delete";
            }
            return null;
        }
        [HttpPut]
        public async Task<IActionResult> Edit(StoreCategoryDto catgoryDto)
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestBaseUri);
                var requestUrl = "store/categories/edit";
            }
            //var responseMessage = await httpClient.GetAsync(requestUrl);
            //var contentString = await responseMessage.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<IEnumerable<LoginViewModel>>(contentString);

            return null;
        }
        public async Task<IActionResult> Details(int? categoryId)
        {
            return View("Details");
        }
        [HttpGet]
        [Route("listing")]
        public async Task<IActionResult> Liste()//IEnumerable<StoreCategoryDto> categories)
        {
            IEnumerable<StoreCategoryDto> storeCategories = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestBaseUri);
                var requestUri = "store/categories";
                var responseMessage = await httpClient.GetAsync(requestUri);
                var contentString = await responseMessage.Content.ReadAsStringAsync();
                int h = 8;
                var result = JsonConvert.DeserializeObject<IEnumerable<StoreCategoryDto>>(contentString);

                if (responseMessage.IsSuccessStatusCode)
                {
                    storeCategories = Mapper.Map<IEnumerable<StoreCategoryDto>>(result);
                }
            }
            return View(storeCategories);
        }
    }
    public interface IHttpHandler
    {
        //HttpResponseMessage Get(string url);
        //HttpResponseMessage Post(string url, HttpContent content);
        //Task<HttpResponseMessage> GetAsync(string url);
        //Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        //HttpClient GetClient();
    }
}





// Private Constructor  aka SingleTon Pattern ?

// Should All Form have POST as method , what ABout vs GET ?

//https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.infrastructure.iactionresulttypemapper.convert?view=aspnetcore-6.0

//https://thecodeblogger.com/2021/06/02/which-type-should-be-returned-from-net-core-web-api-actions/

//https://code-maze.com/asynchronous-programming-with-async-and-await-in-asp-net-core/

//https://www.pluralsight.com/guides/advanced-tips-using-task-run-async-wait

// Unit Test this Controller , mocking api Call
// then TDD  Store & Product features

//then BDD Ordering & signalR  and then Unit Testing 
// Event Aggregation 
//Adapter 
//Facade, Builder
//Other patters 