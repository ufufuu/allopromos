using allopromo.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
namespace allopromo.Controllers
{

    //Uninstall-Package OpenIdPortableArea –RemoveDependencies
    public class NotifyController
    {
        private readonly NotifyHub _notifyHub;
        [HttpGet]
        [Route("api/notify/userName")]
        public void Get(string userName, string message)
        {
            //return
                //_notifyHub.Send(userName, message);
        }
    }
}
