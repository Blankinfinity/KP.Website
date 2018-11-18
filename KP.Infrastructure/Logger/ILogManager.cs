using Serilog;

namespace KP.Infrastructure.Logger
{
    public interface ILogManager
    {
        ILogger CreateLogger();
    }
}
