using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Route("Manage/[controller]")]
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string keyWord)
        {
            var searchData = new List<string>();
            searchData = new List<string>()
            {
            };
            searchData.Add("aaa");
            searchData.Add("bbb");
            searchData.Add("ccc");
            var foundResult = searchData.Where(x => x.Contains(keyWord));
            return View(foundResult);
        }
    }
}
