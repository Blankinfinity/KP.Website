using System;
using Serilog;
using Serilog.Events;

namespace KP.Infrastructure.Logger
{
    public class LogManager : ILogManager
    {
        public ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Is(LogEventLevel.Debug)
                .WriteTo.File(Environment.MachineName + ".log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
