using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class VerboseExtensionsTests
{
    #region Verbose Methods Without Exception
    
    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithMessage_LogsAtTraceLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace, message);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Verbose_WithNullMessage_LogsAtTraceLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithOneProperty_LogsAtTraceLevel(
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithOneProperty_NullValue_LogsAtTraceLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose<string?>(message, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithTwoProperties_LogsAtTraceLevel(
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, prop0, prop1);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithThreeProperties_LogsAtTraceLevel(
        string message,
        string prop0,
        int prop1, 
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, prop0, prop1, prop2);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithFourProperties_LogsAtTraceLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, prop0, prop1, prop2, prop3);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithFiveProperties_LogsAtTraceLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3,
        long prop4)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithSixProperties_LogsAtTraceLevel(
        string message,
        string prop0, 
        int prop1, 
        bool prop2, 
        double prop3, 
        long prop4, 
        decimal prop5)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Verbose Methods With Exception

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithMessageAndException_LogsAtTraceLevelWithException(
        string message,
        Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Contain(message);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithNullMessageAndException_LogsAtTraceLevel(Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, null);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndOneProperty_LogsAtTraceLevel(
        Exception exception,
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, propertyValue);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndTwoProperties_LogsAtTraceLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, prop0, prop1);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndThreeProperties_LogsAtTraceLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, prop0, prop1, prop2);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndFourProperties_LogsAtTraceLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, prop0, prop1, prop2, prop3);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndFiveProperties_LogsAtTraceLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3,
        long prop4)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithExceptionAndSixProperties_LogsAtTraceLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3,
        long prop4,
        decimal prop5)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose(exception, message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Trace);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Logger State Tests

    [Fact]
    public void Verbose_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Debug
        };

        // Act
        testLogger.Verbose("test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Verbose_WhenLoggerDisabledWithException_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Debug
        };
        var exception = new InvalidOperationException("test");

        // Act
        testLogger.Verbose(exception, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Verbose_WhenLoggerDisabledWithProperties_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Debug
        };

        // Act
        testLogger.Verbose("test message", "prop1", 42, true);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Verbose_WhenLoggerEnabled_Logs()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Trace
        };

        // Act
        testLogger.Verbose("test message");

        // Assert
        testLogger.AssertLogCount(1);
        testLogger.AssertLogEntry(LogLevel.Trace, "test message");
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithComplexObjectProperty_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.Verbose(message, complexObject);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithMixedNullAndValueProperties_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose<string?, int?, bool?>(message, null, 42, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Verbose_MultipleCallsInSequence_LogsAll()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose("First message");
        testLogger.Verbose("Second message", "prop");
        testLogger.Verbose(new Exception("test"), "Third message");

        // Assert
        testLogger.AssertLogCount(3);
        var entries = testLogger.LogEntries.ToList();
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Trace));
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithEmptyString_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose("", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Verbose_WithWhitespace_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Verbose("   ", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Trace);
        testLogger.AssertLogCount(1);
    }

    #endregion
}