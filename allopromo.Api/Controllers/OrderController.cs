using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string hello = "hey";
            return Ok(hello);
        }
        [HttpPost]
        public IActionResult Post()
        {
            string hello = "hey";
            return Ok(hello);
        }
    }
}


















//https://stackoverflow.com/questions/4181198/how-to-hash-a-password

// 6/ Test React - Login Automation

// 3- Resiliency , login, auth, crating store <- mediatR or other Patterns !

// 4 - Caching 
// 5 - MVC Super Admin,  Admin
// 7 - store Type : store just or restaurant ? integration abstract , interface -> solid principles
// 8 - DesJardins Courtage en Ligne | AMF ?
// 9 , 2- Odoo Infrastucture integrated - Delivery Order ????


// 1 -  store status | enum ? , struct, | ensure User Status
// 2/ 10 - Integrage Identity Server in Infrastructure

// Onion | Clean Architecture Notes
/* project Root is the Startup or ConfigureServices. where Infrastructure project is referenced
 * and not anywhere else
*/