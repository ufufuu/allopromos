using allopromo.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Services
{
    public class ErrorService
    {
        public ErrorService()
        {
            //400
            throw new AppException("Email or Password incorrect");
            //404
            throw new KeyNotFoundException("Account not Found");
        }

    }
}
