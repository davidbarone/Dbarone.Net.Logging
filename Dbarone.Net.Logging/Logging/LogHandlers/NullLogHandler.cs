using System.Reflection;

namespace Dbarone.Net.Logging;

public class NullLogger : ILogHandler
{
    public void HandleLog(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state)
    {
        // do nothing
    }
}
