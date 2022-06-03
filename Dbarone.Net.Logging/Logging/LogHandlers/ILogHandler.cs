namespace Dbarone.Net.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

/// <summary>
/// Represents a log handler.
/// </summary>
public interface ILogHandler
{
    /// <summary>
    /// Handles a log event.
    /// </summary>
    /// <param name="caller">The calling object raising the log event.</param>
    /// <param name="message">The log message.</param>
    /// <param name="logLevel">The log level.</param>
    /// <param name="logStatus">The log status.</param>
    /// <param name="exception">The log exception (if any).</param>
    /// <param name="state">Optional log state.</param>
    void HandleLog(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state);
}
