using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Infrastructure.Logging
{
    public interface ILoggerAdapter<T>
    {

    }
    public class LoggerAdapter<T>:ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {}
        public void LogWarning()
        {}
        public void LogInformation()
        {
        }
    }
}
