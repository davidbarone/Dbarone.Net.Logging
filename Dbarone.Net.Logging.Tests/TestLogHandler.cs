namespace Dbarone.Net.Logging.Tests;
using System.Reflection;
using System;
using System.Collections.Generic;

/// <summary>
/// Captures log events for assertions at a later date.
/// </summary>
public class TestLogHandler : LogHandler
{
    public List<LogEventInfo> LogEvents = new List<LogEventInfo>();

    public override void HandleLog(MethodBase caller, string message, LogLevel logLevel, LogStatus logStatus, Exception? exception, object? state) {
        LogEvents.Add(new LogEventInfo(caller, logLevel, logStatus, message, exception, state));
    }
}