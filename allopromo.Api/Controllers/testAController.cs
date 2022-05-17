using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testAController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string hello = "hey";
            return Ok(hello);
        }
    }
}
