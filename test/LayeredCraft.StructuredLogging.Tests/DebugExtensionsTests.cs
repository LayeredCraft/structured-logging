using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class DebugExtensionsTests
{
    #region Debug Methods Without Exception
    
    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithMessage_LogsAtDebugLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(message);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug, message);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Debug_WithNullMessage_LogsAtDebugLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithOneProperty_LogsAtDebugLevel(
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(message, propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithOneProperty_NullValue_LogsAtDebugLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug<string?>(message, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithTwoProperties_LogsAtDebugLevel(
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(message, prop0, prop1);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithThreeProperties_LogsAtDebugLevel(
        string message,
        string prop0,
        int prop1, 
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(message, prop0, prop1, prop2);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithFourProperties_LogsAtDebugLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(message, prop0, prop1, prop2, prop3);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithFiveProperties_LogsAtDebugLevel(
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
        testLogger.Debug(message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithSixProperties_LogsAtDebugLevel(
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
        testLogger.Debug(message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Debug Methods With Exception

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithMessageAndException_LogsAtDebugLevelWithException(
        string message,
        Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(exception, message);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Contain(message);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithNullMessageAndException_LogsAtDebugLevel(Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(exception, null);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndOneProperty_LogsAtDebugLevel(
        Exception exception,
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(exception, message, propertyValue);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndTwoProperties_LogsAtDebugLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(exception, message, prop0, prop1);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndThreeProperties_LogsAtDebugLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug(exception, message, prop0, prop1, prop2);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndFourProperties_LogsAtDebugLevel(
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
        testLogger.Debug(exception, message, prop0, prop1, prop2, prop3);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndFiveProperties_LogsAtDebugLevel(
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
        testLogger.Debug(exception, message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithExceptionAndSixProperties_LogsAtDebugLevel(
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
        testLogger.Debug(exception, message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Logger State Tests

    [Fact]
    public void Debug_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };

        // Act
        testLogger.Debug("test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Debug_WhenLoggerDisabledWithException_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };
        var exception = new InvalidOperationException("test");

        // Act
        testLogger.Debug(exception, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Debug_WhenLoggerDisabledWithProperties_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };

        // Act
        testLogger.Debug("test message", "prop1", 42, true);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Debug_WhenLoggerEnabled_Logs()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Debug
        };

        // Act
        testLogger.Debug("test message");

        // Assert
        testLogger.AssertLogCount(1);
        testLogger.AssertLogEntry(LogLevel.Debug, "test message");
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithComplexObjectProperty_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.Debug(message, complexObject);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithMixedNullAndValueProperties_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug<string?, int?, bool?>(message, null, 42, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Debug_MultipleCallsInSequence_LogsAll()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug("First message");
        testLogger.Debug("Second message", "prop");
        testLogger.Debug(new Exception("test"), "Third message");

        // Assert
        testLogger.AssertLogCount(3);
        var entries = testLogger.LogEntries.ToList();
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Debug));
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithEmptyString_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug("", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Debug_WithWhitespace_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Debug("   ", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Debug);
        testLogger.AssertLogCount(1);
    }

    #endregion
}