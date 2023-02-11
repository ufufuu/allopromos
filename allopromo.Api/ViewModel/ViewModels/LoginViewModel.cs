using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.ViewModel.ViewModels
{


    //public class LoginViewModel
    //{
    //    public string UserName { get; set; }
    //    public string UserPassword { get; set; }
    //}

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string UserJwtToken { get; set; }
    }
}
