using allopromoInfrastructure.Abstract;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoInfrastructure.Logging
{
    public class LoggerManager : ILoggerManager //Serilog.ILogger
    {
        void ILogger.Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
