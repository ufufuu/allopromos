using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
