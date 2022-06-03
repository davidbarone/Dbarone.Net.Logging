using System.Reflection;

namespace Dbarone.Net.Logging;

/// <summary>
/// Base class for log handlers. Includes basic log templates.
/// </summary>
public abstract class LogHandler : ILogHandler
{
    public abstract void HandleLog(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state);

    protected string GetLogStringShort(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state)
    {
        return $"{DateTime.Now} | {logStatus} | {logLevel} | {message}";
    }
}