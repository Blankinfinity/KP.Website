using System;
using KP.Infrastructure.Extensions;
using Serilog.Events;

namespace KP.Infrastructure.Configuration.Options
{
    public class LoggingOptions : OptionsBase
    {
        public LoggingOptions(IAppSetting appSettings) : base(appSettings)
        {
        }

        public string SeqFile => GetString().Default(@"log.txt");
        public LogEventLevel LogLevel
        {
            get
            {
                var level = GetString().Default("Error");
                if (Enum.TryParse(level, out LogEventLevel logEvent))
                {
                    return logEvent;
                }

                return (LogEventLevel)Enum.ToObject(typeof(LogEventLevel), 4);
            }
        }
    }
}
