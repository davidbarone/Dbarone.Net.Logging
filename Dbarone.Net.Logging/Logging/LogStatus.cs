using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The logging status.
/// </summary>
public enum LogStatus
{
    /// <summary>
    /// No additional log status.
    /// </summary>
    None = 0,

    /// <summary>
    /// Marks the beginning of a routine.
    /// </summary>
    Begin = 2,

    /// <summary>
    /// Marks the end of a routine.
    /// </summary>
    End = 3,

    /// <summary>
    /// Marks the overall start of a process.
    /// </summary>
    Start = 4,

    /// <summary>
    /// Marks the overall success of a process.
    /// </summary>
    Success = 5,

    /// <summary>
    /// Marks the overall failure of a process.
    /// </summary>
    Failure = 6,
}
