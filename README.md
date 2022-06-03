# Dbarone.Net.Logging
A simple .NET logging library.

## Summary

Logging is a common task in enterprise applications. This library contains simple `Logger` class to provide a number of overloaded Log methods as well as some additional specialised event logging methods:

| Method  | Purpose                                 |
| ------- | --------------------------------------- |
| Log     | To log an event.                        |
| Begin   | To log the beginning of a routine.      |
| End     | To log the end of a routine.            |
| Start   | To log the start of an overall process. |
| Success | To log the overall success a process.   |
| Failure | To log the overall failure a process.   |

Log handling is implemented by types implementing the `ILogHandler` interface. LogHandlers are added to the Logger via the constructor. Out of the box, there are several `ILogHandler` types:

| Type              | Purpose                     |
| ----------------- | --------------------------- |
| ConsoleLogHandler | Logs events to the console. |

## LogLevel

The log events support 6 log levels:

| LogLevel    | Purpose                                                         |
| ----------- | --------------------------------------------------------------- |
| Trace       | Used to mark trail of execution.                                |
| Debug       | Used for debugging purposes.                                    |
| Information | Used for informational purposes.                                |
| Warning     | Something non-standard happened, but execution continued.       |
| Error       | Something bad happened. Execution stopped.                      |
| Fatal       | Something very bad happened. The entire application terminated. |

## Sample Code

The following code shows how to use the library. Typically, you would use an IoC to inject configured objects rather than instantiate inline:

``` C#
namespace Dbarone.Net.Logging.Tests;
using Xunit;
using System;
using System.Linq;

public class SomeClass
{
    ILogger logger;

    public SomeClass() {
        ILogHandler handler = new ConsoleLogHandler();
        ILogger logger = new Logger(new ILogHandler[] { handler });
    }

    public void ProcessStuff() {
        
        // Do some stuff.
        
        Logger.Log(LogLevel.Information, "I'm logging some stuff.");

        // Do some more stuff.
    }
}
```


