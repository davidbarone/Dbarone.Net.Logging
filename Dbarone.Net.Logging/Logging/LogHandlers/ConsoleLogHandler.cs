using System.Reflection;

namespace Dbarone.Net.Logging;

/// <summary>
/// Logs events to the console.
/// </summary>
public class ConsoleLogHandler : LogHandler
{
    public override void HandleLog(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state) {
        var str = GetLogStringShort(caller, message, logLevel, logStatus, exception, state);
        Console.WriteLine(str);
    }
}