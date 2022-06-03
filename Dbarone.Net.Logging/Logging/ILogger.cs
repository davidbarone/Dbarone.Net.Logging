namespace Dbarone.Net.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface for logging.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs the beginning of a routine.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <param name="state">Optional state.</param>
    void Begin(string message = "", object? state = null);

    /// <summary>
    /// Logs the end of a routine.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <param name="state">Optional state.</param>
    void End(string message = "", object? state = null);

    /// <summary>
    /// Logs the overall start of a process.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <param name="state">Optional state.</param>
    void Start(string message = "", object? state = null);

    /// <summary>
    /// Logs the overall success of a process.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <param name="state">Optional state.</param>
    void Success(string message = "", object? state = null);
    
        /// <summary>
    /// Logs the overall failure of a process.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <param name="state">Optional state.</param>
    void Failure(string message = "", object? state = null);
    
    /// <summary>
    /// Logs an event
    /// </summary>
    /// <param name="logLevel">The log level.</param>
    /// <param name="message">The log message.</param>
    /// <param name="state">Optional log state.</param>
    void Log(LogLevel logLevel, string message, object? state = null);
    
    /// <summary>
    /// Logs an exception.
    /// </summary>
    /// <param name="exception">The exception thrown.</param>
    /// <param name="state">Optional log state.</param>
    void Log(Exception exception, object? state = null);
}
