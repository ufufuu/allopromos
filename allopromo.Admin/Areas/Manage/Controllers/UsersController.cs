using allopromo.Admin.Models.Dto;
using allopromo.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
namespace allopromo.Admin.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Route("Manage/[controller]")]
    public class UsersController : Controller
    {
        string requestBaseUri = "https://localhost:44367/api/";
        string requestUri = "/user/";
        [HttpGet]
        public async Task<IActionResult> Index(IEnumerable<LoginViewModel> loginViewModel)
        {
            IEnumerable<UserDto> users = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestBaseUri);
                var requestUrl = "user";
                var responseMessage = await httpClient.GetAsync(requestUrl);
                var contentString = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<LoginViewModel>>(contentString);
                if (responseMessage.IsSuccessStatusCode)
                {
                    users =
                        Mapper.Map<IEnumerable<UserDto>>(result);
                }
            }
            return View(users);
        }
    }
}