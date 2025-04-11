using allopromo.Admin.Models.Dto;
using allopromo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
namespace allopromo.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private string API_BASE = Constantes.ApiInfo.API_BASE;
        private string API_CREATE_DEPARTMENT = Constantes.ApiInfo.API_CREATE_DEPARTMENT;
        private string API_GET_DEPARTMENT = Constantes.ApiInfo.API_GET_DEPARTMENT;
        private string API_GET_DEPARTMENTS = Constantes.ApiInfo.API_GET_DEPARTMENTS;
        private readonly IHttpClientFactory _httpClientFactory;
        public DepartmentController(IHttpClientFactory httpClientFactory, ILogger<DepartmentController> logger)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                if (departmentDto == null)
                {
                    return BadRequest();
                }
                else
                {
                    try
                    {
                        var department = new DepartmentDto { departmentId = new Guid().ToString(), departmentName = departmentDto.departmentName };
                        var jsonDepartment = JsonConvert.SerializeObject(department);
                        var httpContent = new StringContent(jsonDepartment, System.Text.Encoding.UTF8, "application/json");
                        using (var httpClient = _httpClientFactory.CreateClient())
                        {
                            httpClient.PostAsync(new Uri(API_BASE + API_CREATE_DEPARTMENT), httpContent);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return View(departmentDto);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departmentList = new List<DepartmentDto>();
            try
            {
                using(var httpClient= _httpClientFactory.CreateClient())
                {
                    //httpClient.DefaultRequestHeaders.Accept.Clear();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(API_BASE + API_GET_DEPARTMENTS),
                        Content = new StringContent("application/json", System.Text.Encoding.UTF8,
                        MediaTypeNames.Application.Json)
                    };
                    var json = await httpClient.GetAsync(new Uri(API_BASE+ API_GET_DEPARTMENTS));
                    var dataStr = await json.Content.ReadAsStringAsync();
                    departmentList = (List<DepartmentDto>)JsonConvert.DeserializeObject(dataStr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(departmentList.AsEnumerable());
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
            }
            return View("Create");
        }
        [HttpPut]
        public IActionResult Put()
        {
            return null;
        }
    }
}
