using allopromoInfrastructure.Abstract;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromoInfrastructure.Logging
{
    public class LoggerManager : ILoggerManager//, Serilog.ILogger
    {
        public void Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
