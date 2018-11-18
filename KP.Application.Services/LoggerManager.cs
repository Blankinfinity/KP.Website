using KP.Application.Contracts;
using Serilog;
using Serilog.Events;
using System;

namespace KP.Application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = Log.Logger;

        public LoggerManager()
        {
        }

        public ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Is(LogEventLevel.Debug)
                .WriteTo.File(Environment.MachineName + ".log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Information(message);
        }

        public void LogWarn(string message)
        {
            logger.Warning(message);
        }
    }
}
