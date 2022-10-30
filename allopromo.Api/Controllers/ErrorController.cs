using allopromo.Model.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Controllers.Errors
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ErrorController : ControllerBase
    {
        [TypeFilter(typeof(HttpResponseExceptionFilter))]
        //[Route("/error")]
        [HttpGet]
        public IActionResult GetError() //=> Problem(); // Problem -> Internal Server Error()
        {
            throw new HttpResponseException("An Exception a ete Jete"); //then Redirect to Erropage if any
        }
    }
}
