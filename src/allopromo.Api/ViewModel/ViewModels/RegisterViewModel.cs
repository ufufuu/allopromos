﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.ViewModel.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public RegisterViewModel()
        {

        }
    }
}
