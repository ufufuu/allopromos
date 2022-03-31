using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monEpicierClient.Controllers
{
    public class MerchantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
