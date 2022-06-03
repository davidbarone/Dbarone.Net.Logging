namespace Dbarone.Net.Logging.Tests;
using Xunit;
using System;
using System.Linq;

public class FooBar
{
    ILogger Logger;
    public FooBar(ILogger logger)
    {
        this.Logger = logger;
    }
    public void DoBeginEvent()
    {
        Logger.Begin();
    }

    public void DoEndEvent()
    {
        Logger.End();
    }

    public void DoStartEvent()
    {
        Logger.Start();
    }

    public void DoSuccessEvent()
    {
        Logger.Success();
    }

    public void DoFailureEvent()
    {
        Logger.Failure();
    }

    public void MethodWithMultipleLogs()
    {
        Logger.Begin();
        Logger.Log(LogLevel.Information, "foo");
        Logger.Log(LogLevel.Information, "bar");
        Logger.Log(LogLevel.Information, "baz");
        Logger.End();
    }

    public void MethodWithException()
    {
        try
        {
            throw new System.Exception("foobar exception.");
        }
        catch (Exception ex)
        {
            Logger.Log(ex);
        }
    }

    public void Baz() {
        Logger.Log(LogLevel.Information, "Something happened here.");
    }
}

public class LoggingTests
{
    private ILogger getLogger(ILogHandler handler)
    {
        var logger = new Logger(new ILogHandler[] { handler });
        return logger;
    }

    public TestLogHandler getHandler()
    {
        TestLogHandler handler = new TestLogHandler();
        return handler;
    }

    [Fact]
    public void Test_Begin()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.DoBeginEvent();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Information, handler.LogEvents.First().LogLevel);
        Assert.Equal(LogStatus.Begin, handler.LogEvents.First().LogStatus);
    }

    [Fact]
    public void Test_End()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.DoEndEvent();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Information, handler.LogEvents.First().LogLevel);
        Assert.Equal(LogStatus.End, handler.LogEvents.First().LogStatus);
    }

    [Fact]
    public void Test_Start()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.DoStartEvent();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Information, handler.LogEvents.First().LogLevel);
        Assert.Equal(LogStatus.Start, handler.LogEvents.First().LogStatus);
    }

    [Fact]
    public void Test_Success()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.DoSuccessEvent();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Information, handler.LogEvents.First().LogLevel);
        Assert.Equal(LogStatus.Success, handler.LogEvents.First().LogStatus);
    }

    [Fact]
    public void Test_Failure()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.DoFailureEvent();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Information, handler.LogEvents.First().LogLevel);
        Assert.Equal(LogStatus.Failure, handler.LogEvents.First().LogStatus);
    }

    [Fact]
    public void Test_Multiple_Events()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.MethodWithMultipleLogs();

        // Assert
        Assert.Equal(5, handler.LogEvents.Count);
    }

    [Fact]
    public void Test_ExceptionEvent()
    {
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.MethodWithException();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal(LogLevel.Error, handler.LogEvents.First().LogLevel);
        Assert.Equal("foobar exception.", handler.LogEvents.First().Message);
    }

    [Fact]
    public void WhenLog_CheckCaller(){
        // Arrange
        var handler = getHandler();
        var logger = getLogger(handler);
        var fooBar = new FooBar(logger);

        // Act
        fooBar.Baz();

        // Assert
        Assert.Single(handler.LogEvents);
        Assert.Equal("Baz", handler.LogEvents.First().Caller.Name);
        Assert.Equal(typeof(FooBar), handler.LogEvents.First().Caller.DeclaringType);
    }
}