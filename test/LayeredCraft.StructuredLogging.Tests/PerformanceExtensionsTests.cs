using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class PerformanceExtensionsTests
{
    #region TimeOperation Tests

    [Theory]
    [AutoNSubstituteData]
    public void TimeOperation_CreatesDisposableTimer(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var timer = testLogger.TimeOperation(operationName);

        // Assert
        timer.Should().NotBeNull();
        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
    }

    [Theory]
    [AutoNSubstituteData]
    public void TimeOperation_WhenDisposed_LogsCompletion(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (var timer = testLogger.TimeOperation(operationName))
        {
            // Timer is active
        } // Disposal happens here

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 2); // Start and end messages
        var entries = testLogger.GetLogEntries(LogLevel.Information).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[0].FormattedMessage.Should().Contain(operationName);
        entries[1].FormattedMessage.Should().Contain("Completed operation");
        entries[1].FormattedMessage.Should().Contain(operationName);
        entries[1].FormattedMessage.Should().Contain("ms");
    }

    [Theory]
    [AutoNSubstituteData]
    public void TimeOperation_WithCustomLogLevel_UsesSpecifiedLevel(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (var timer = testLogger.TimeOperation(operationName, LogLevel.Warning))
        {
            // Timer is active
        }

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 2); // Start and end messages
        testLogger.AssertLogCount(LogLevel.Information, 0); // No information messages
    }

    [Theory]
    [AutoNSubstituteData]
    public void TimeOperation_MultipleDispose_DoesNotThrow(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var timer = testLogger.TimeOperation(operationName);

        // Act & Assert
        timer.Dispose();
        var action = () => timer.Dispose();
        action.Should().NotThrow();
        
        // Should only log once
        testLogger.AssertLogCount(LogLevel.Information, 2);
    }

    [Theory]
    [AutoNSubstituteData]
    public void TimeOperation_WithLoggerDisabled_DoesNotLog(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        using (var timer = testLogger.TimeOperation(operationName))
        {
            // Timer is active
        }

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    #endregion

    #region TimeAsync<TResult> Tests

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTaskResult_TimesOperationAndReturnsResult(string operationName, int expectedResult)
    {
        // Arrange
        var testLogger = new TestLogger();
        var taskToTime = Task.FromResult(expectedResult);

        // Act
        var result = await testLogger.TimeAsync(operationName, () => taskToTime);

        // Assert
        result.Should().Be(expectedResult);
        testLogger.AssertLogCount(LogLevel.Information, 2); // Start and end messages
        var entries = testLogger.GetLogEntries(LogLevel.Information).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[1].FormattedMessage.Should().Contain("Completed operation");
        entries[1].FormattedMessage.Should().Contain("ms");
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTaskResultAndCustomLogLevel_UsesSpecifiedLevel(string operationName, string expectedResult)
    {
        // Arrange
        var testLogger = new TestLogger();
        var taskToTime = Task.FromResult(expectedResult);

        // Act
        var result = await testLogger.TimeAsync(operationName, () => taskToTime, LogLevel.Warning);

        // Assert
        result.Should().Be(expectedResult);
        testLogger.AssertLogCount(LogLevel.Warning, 2);
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTaskResultException_LogsErrorAndRethrows(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new InvalidOperationException("Test exception");
        
        // Act & Assert
        var act = async () => await testLogger.TimeAsync<int>(operationName, () => throw exception);
        await act.Should().ThrowAsync<InvalidOperationException>();
        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
        testLogger.AssertLogCount(LogLevel.Error, 1); // Error message
        
        var errorEntry = testLogger.GetLogEntries(LogLevel.Error).First();
        errorEntry.FormattedMessage.Should().Contain("Failed operation");
        errorEntry.FormattedMessage.Should().Contain(operationName);
        errorEntry.FormattedMessage.Should().Contain("ms");
        errorEntry.Exception.Should().Be(exception);
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithDelayedTaskResult_MeasuresActualTime(string operationName, bool expectedResult)
    {
        // Arrange
        var testLogger = new TestLogger();
        var delayMs = 50;
        
        // Act
        var result = await testLogger.TimeAsync(operationName, async () =>
        {
            await Task.Delay(delayMs);
            return expectedResult;
        });

        // Assert
        result.Should().Be(expectedResult);
        testLogger.AssertLogCount(LogLevel.Information, 2);
        var completionEntry = testLogger.GetLogEntries(LogLevel.Information).Last();
        completionEntry.FormattedMessage.Should().Contain("Completed operation");
        completionEntry.FormattedMessage.Should().Contain("ms");
    }

    #endregion

    #region TimeAsync (void) Tests

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTask_TimesOperation(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var executed = false;

        // Act
        await testLogger.TimeAsync(operationName, async () =>
        {
            await Task.Delay(10);
            executed = true;
        });

        // Assert
        executed.Should().BeTrue();
        testLogger.AssertLogCount(LogLevel.Information, 2); // Start and end messages
        var entries = testLogger.GetLogEntries(LogLevel.Information).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[1].FormattedMessage.Should().Contain("Completed operation");
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTaskAndCustomLogLevel_UsesSpecifiedLevel(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        await testLogger.TimeAsync(operationName, () => Task.CompletedTask, LogLevel.Debug);

        // Assert
        testLogger.AssertLogCount(LogLevel.Debug, 2);
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithTaskException_LogsErrorAndRethrows(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new InvalidOperationException("Test exception");
        
        // Act & Assert
        var act = async () => await testLogger.TimeAsync(operationName, () => throw exception);
        await act.Should().ThrowAsync<InvalidOperationException>();
        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
        testLogger.AssertLogCount(LogLevel.Error, 1); // Error message
        
        var errorEntry = testLogger.GetLogEntries(LogLevel.Error).First();
        errorEntry.FormattedMessage.Should().Contain("Failed operation");
        errorEntry.Exception.Should().Be(exception);
    }

    #endregion

    #region Time<TResult> Tests

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithFuncResult_TimesOperationAndReturnsResult(string operationName, decimal expectedResult)
    {
        // Arrange
        var testLogger = new TestLogger();
        var executed = false;

        // Act
        var result = testLogger.Time(operationName, () =>
        {
            executed = true;
            return expectedResult;
        });

        // Assert
        result.Should().Be(expectedResult);
        executed.Should().BeTrue();
        testLogger.AssertLogCount(LogLevel.Information, 2); // Start and end messages
        var entries = testLogger.GetLogEntries(LogLevel.Information).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[1].FormattedMessage.Should().Contain("Completed operation");
        entries[1].FormattedMessage.Should().Contain("ms");
    }

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithFuncResultAndCustomLogLevel_UsesSpecifiedLevel(string operationName, long expectedResult)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        var result = testLogger.Time(operationName, () => expectedResult, LogLevel.Critical);

        // Assert
        result.Should().Be(expectedResult);
        testLogger.AssertLogCount(LogLevel.Critical, 2);
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithFuncException_LogsErrorAndRethrows(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new ArgumentException("Test exception");
        
        // Act & Assert
        var act = () => testLogger.Time<string>(operationName, () => throw exception);
        act.Should().Throw<ArgumentException>();
        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
        testLogger.AssertLogCount(LogLevel.Error, 1); // Error message
        
        var errorEntry = testLogger.GetLogEntries(LogLevel.Error).First();
        errorEntry.FormattedMessage.Should().Contain("Failed operation");
        errorEntry.Exception.Should().Be(exception);
    }

    #endregion

    #region Time (void) Tests

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithAction_TimesOperation(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var executed = false;

        // Act
        testLogger.Time(operationName, () => { executed = true; });

        // Assert
        executed.Should().BeTrue();
        testLogger.AssertLogCount(LogLevel.Information, 2); // Start and end messages
        var entries = testLogger.GetLogEntries(LogLevel.Information).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[1].FormattedMessage.Should().Contain("Completed operation");
    }

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithActionAndCustomLogLevel_UsesSpecifiedLevel(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var executed = false;

        // Act
        testLogger.Time(operationName, () => { executed = true; }, LogLevel.Trace);

        // Assert
        executed.Should().BeTrue();
        testLogger.AssertLogCount(LogLevel.Trace, 2);
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithActionException_LogsErrorAndRethrows(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new NotSupportedException("Test exception");
        
        // Act & Assert
        var act = () => testLogger.Time(operationName, () => throw exception);
        act.Should().Throw<NotSupportedException>();
        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
        testLogger.AssertLogCount(LogLevel.Error, 1); // Error message
        
        var errorEntry = testLogger.GetLogEntries(LogLevel.Error).First();
        errorEntry.FormattedMessage.Should().Contain("Failed operation");
        errorEntry.Exception.Should().Be(exception);
    }

    #endregion

    #region TimeMethod Tests

    [Fact]
    public void TimeMethod_CreatesDisposableTimer()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var timer = testLogger.TimeMethod();

        // Assert
        timer.Should().NotBeNull();
        testLogger.AssertLogCount(LogLevel.Debug, 1); // Start message with method name
    }

    [Fact]
    public void TimeMethod_WhenDisposed_LogsCompletionWithMethodName()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (var timer = testLogger.TimeMethod())
        {
            // Timer is active
        }

        // Assert
        testLogger.AssertLogCount(LogLevel.Debug, 2);
        var entries = testLogger.GetLogEntries(LogLevel.Debug).ToList();
        entries[0].FormattedMessage.Should().Contain("Starting operation");
        entries[0].FormattedMessage.Should().Contain("PerformanceExtensionsTests.TimeMethod_WhenDisposed_LogsCompletionWithMethodName");
        entries[1].FormattedMessage.Should().Contain("Completed operation");
        entries[1].FormattedMessage.Should().Contain("PerformanceExtensionsTests.TimeMethod_WhenDisposed_LogsCompletionWithMethodName");
    }

    [Fact]
    public void TimeMethod_WithCustomLogLevel_UsesSpecifiedLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (var timer = testLogger.TimeMethod(LogLevel.Warning))
        {
            // Timer is active
        }

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 2);
        testLogger.AssertLogCount(LogLevel.Debug, 0);
    }

    [Fact]
    public void TimeMethod_WithLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };

        // Act
        using (var timer = testLogger.TimeMethod())
        {
            // Timer is active
        }

        // Assert
        testLogger.AssertLogCount(LogLevel.Debug, 0);
        testLogger.AssertNoLogEntries();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void TimeOperation_WithEmptyOperationName_CreatesTimer()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var timer = testLogger.TimeOperation("");

        // Assert
        timer.Should().NotBeNull();
        testLogger.AssertLogCount(LogLevel.Information, 1);
    }

    [Fact]
    public void TimeOperation_WithWhitespaceOperationName_CreatesTimer()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var timer = testLogger.TimeOperation("   ");

        // Assert
        timer.Should().NotBeNull();
        testLogger.AssertLogCount(LogLevel.Information, 1);
    }

    [Theory]
    [AutoNSubstituteData]
    public async Task TimeAsync_WithCancelledTask_PropagatesCancellation(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        var act = async () => await testLogger.TimeAsync(operationName, () => Task.FromCanceled(cts.Token));
        await act.Should().ThrowAsync<OperationCanceledException>();

        testLogger.AssertLogCount(LogLevel.Information, 1); // Start message
        testLogger.AssertLogCount(LogLevel.Error, 1); // Error message for cancellation
    }

    [Theory]
    [AutoNSubstituteData]
    public void Time_WithComplexObjectResult_ReturnsCorrectly(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var expectedResult = new { Name = "Test", Value = 42 };

        // Act
        var result = testLogger.Time(operationName, () => expectedResult);

        // Assert
        result.Should().Be(expectedResult);
        testLogger.AssertLogCount(LogLevel.Information, 2);
    }

    #endregion
}