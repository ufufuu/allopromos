using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
namespace allopromo.Api.Controllers
{
    public class AisleController:ApiController
    {
        private IAisleService _aisleService { get; set; } 
        private ILogger<IAisleService> _logger { get; set; }
        [HttpGet]
        [Route("/aisles")]
        public IActionResult GetAisles()
        {
            return (IActionResult)_aisleService.GetAisles();
        }
        [HttpPost]
        [RouteAttribute("/aisles/create")]
        public Task<IActionResult> postAisle()
        {
            return null;
        }
    }
}
