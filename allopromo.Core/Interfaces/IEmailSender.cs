using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmainAsync(string email, string subject, string message);
    }
}
