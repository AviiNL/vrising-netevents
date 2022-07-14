using System.Threading.Tasks;
using BepInEx.Logging;

namespace NetEvents.Logger.Handler;

interface ILogHandler
{
    bool Accept(LogLevel level);

    Task Handle(LogLevel level, string message);
}