using allopromo.Api.Infrastructure.Abstract;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Api.Infrastructure.Logging
{
    public class LoggerManager: ILoggerManager //Serilog.ILogger
    {
        public void Write (LogEvent logEvent)
        {
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}
