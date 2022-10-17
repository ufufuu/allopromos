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
    public class OdooController : ControllerBase
    {
        public string odooServerUrl = "https://localhost:8069/";
        public string odooDb = "allopromo";
        public string odooUser = "admin";
        public string odooPwd = "@12345";
        //public XmlRpcClient client = new XmlRpcClient();
        //public 
        //public void Get()
        //{

        //}
    }
}
