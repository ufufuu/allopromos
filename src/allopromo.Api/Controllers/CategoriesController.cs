using Microsoft.AspNetCore.Authorization;
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
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {}
        [HttpPost]
        [Authorize(Roles="Administrators")]
        public Task<IActionResult> PostCategory()
        {
            return null;
        }
        [HttpPost]
        [Authorize(Roles= "Administrators")]
        public Task<IActionResult> GetCategories()
        {
            return null;
        }
    }
}
