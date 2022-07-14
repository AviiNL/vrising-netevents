using System.Threading.Tasks;
using BepInEx.Logging;

namespace NetEvents.Logger.Handler;

class ConsoleLogHandler : ILogHandler
{
    public bool Accept(LogLevel level)
    {
        return level <= LogLevel.Info;
    }

    public Task Handle(LogLevel level, string message)
    {
        Plugin.Instance?.Log.Log(level, message);
        return Task.CompletedTask;
    }
}
