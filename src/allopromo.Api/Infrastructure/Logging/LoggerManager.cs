using allopromo.Api.Infrastructure.Abstract;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Api.Infrastructure.Logging
{
    public class LoggerManager : ILoggerManager //Serilog.ILogger
    {
        void ILogger.Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
