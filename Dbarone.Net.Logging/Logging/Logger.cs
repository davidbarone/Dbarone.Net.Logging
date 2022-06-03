namespace Dbarone.Net.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/// <summary>
/// The logger class.
/// </summary>
public class Logger : MarshalByRefObject, ILogger
{
    ILogHandler[] logHandlers;

    public Logger(ILogHandler[] logHandlers){
        this.logHandlers = logHandlers;
    }

    public void Begin(string message = "", object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, LogLevel.Information, LogStatus.Begin, null, null);
        }
    }

    public void End(string message = "", object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, LogLevel.Information, LogStatus.End, null, null);
        }
    }

    public void Start(string message = "", object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, LogLevel.Information, LogStatus.Start, null, null);
        }
    }

    public void Success(string message = "", object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, LogLevel.Information, LogStatus.Success, null, null);
        }
    }

    public void Failure(string message = "", object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, LogLevel.Information, LogStatus.Failure, null, null);
        }
    }

    public void Log(Exception exception, object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, exception.Message, LogLevel.Error, LogStatus.None, exception, null);
        }
    }

    public void Log(LogLevel logLevel, string message, object? state = null)
    {
        StackTrace trc = new StackTrace();
        var caller = trc.GetFrame(1)!.GetMethod()!;
        foreach (var handler in logHandlers) {
            handler.HandleLog(caller, message, logLevel, LogStatus.None, null, null);
        }
    }
}
