namespace Dbarone.Net.Logging.Tests;
using System;
using System.Reflection;

/// <summary>
/// Information representing a log event.
/// </summary>
public class LogEventInfo
{
    public LogEventInfo(MethodBase caller, LogLevel logLevel, LogStatus logStatus, string message, Exception? exception, object? state)
    {
        this.Caller = caller;
        this.LogLevel = logLevel;
        this.LogStatus = logStatus;
        this.Message = message;
        this.Exception = exception;
        this.State = state;
    }

    /// <summary>
    /// The caller of the log event.
    /// </summary>
    public MethodBase Caller { get; set; } = default!;

    /// <summary>
    /// The log level.
    /// </summary>
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public LogStatus LogStatus { get; set; } = LogStatus.None;
    /// <summary>
    /// The log message.
    /// </summary>
    public string Message { get; set; } = default!;

    /// <summary>
    /// Optional state relating to the logged event.
    /// </summary>
    public object? State { get; set; }

    /// <summary>
    /// Optional exception object raised by caller.
    /// </summary>
    public Exception? Exception { get; set; }
}