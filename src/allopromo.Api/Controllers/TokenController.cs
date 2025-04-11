
using allopromo.Api.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
namespace allopromo.Api.Controllers
{
    public class TokenController:ControllerBase
    {
        private SignInManager<RegisterViewModel> _signingManager { get; set; }

        [HttpGet]
        //[allopromo.Api.Infrastructure.Filters.BasicAuthenticationFilter]
        public IActionResult Get([FromBody] RegisterViewModel user)
        {
            return null;
        }
    }
}
