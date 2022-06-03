using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The logging level.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Used to mark trail of execution.
    /// </summary>
    Trace = 1,

    /// <summary>
    /// Used for debugging purposes.
    /// </summary>
    Debug = 2,

    /// <summary>
    /// Used for informational purposes.
    /// </summary>
    Information = 3,

    /// <summary>
    /// Something non-standard happened, but execution continued.
    /// </summary>
    Warning = 4,

    /// <summary>
    /// Something bad happened. Execution stopped.
    /// </summary>
    Error = 5,

    /// <summary>
    /// Something very bad happened. The entire application terminated.
    /// </summary>
    Fatal = 6
}
