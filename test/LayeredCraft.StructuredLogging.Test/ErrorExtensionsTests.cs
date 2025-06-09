using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Test.TestKit.Attributes;
using LayeredCraft.StructuredLogging.Testing;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Test;

public class ErrorExtensionsTests
{
    #region Error Methods Without Exception
    
    [Theory]
    [AutoNSubstituteData]
    public void Error_WithMessage_LogsAtErrorLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(message);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error, message);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Error_WithNullMessage_LogsAtErrorLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithOneProperty_LogsAtErrorLevel(
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(message, propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithOneProperty_NullValue_LogsAtErrorLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error<string?>(message, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithTwoProperties_LogsAtErrorLevel(
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(message, prop0, prop1);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithThreeProperties_LogsAtErrorLevel(
        string message,
        string prop0,
        int prop1, 
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(message, prop0, prop1, prop2);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithFourProperties_LogsAtErrorLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(message, prop0, prop1, prop2, prop3);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithFiveProperties_LogsAtErrorLevel(
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
        testLogger.Error(message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithSixProperties_LogsAtErrorLevel(
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
        testLogger.Error(message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Error Methods With Exception

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithMessageAndException_LogsAtErrorLevelWithException(
        string message,
        Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(exception, message);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Contain(message);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithNullMessageAndException_LogsAtErrorLevel(Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(exception, null);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndOneProperty_LogsAtErrorLevel(
        Exception exception,
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(exception, message, propertyValue);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndTwoProperties_LogsAtErrorLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(exception, message, prop0, prop1);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndThreeProperties_LogsAtErrorLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error(exception, message, prop0, prop1, prop2);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndFourProperties_LogsAtErrorLevel(
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
        testLogger.Error(exception, message, prop0, prop1, prop2, prop3);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndFiveProperties_LogsAtErrorLevel(
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
        testLogger.Error(exception, message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithExceptionAndSixProperties_LogsAtErrorLevel(
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
        testLogger.Error(exception, message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Logger State Tests

    [Fact]
    public void Error_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Critical
        };

        // Act
        testLogger.Error("test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Error_WhenLoggerDisabledWithException_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Critical
        };
        var exception = new InvalidOperationException("test");

        // Act
        testLogger.Error(exception, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Error_WhenLoggerDisabledWithProperties_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Critical
        };

        // Act
        testLogger.Error("test message", "prop1", 42, true);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Error_WhenLoggerEnabled_Logs()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Error
        };

        // Act
        testLogger.Error("test message");

        // Assert
        testLogger.AssertLogCount(1);
        testLogger.AssertLogEntry(LogLevel.Error, "test message");
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithComplexObjectProperty_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.Error(message, complexObject);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithMixedNullAndValueProperties_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error<string?, int?, bool?>(message, null, 42, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Error_MultipleCallsInSequence_LogsAll()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error("First message");
        testLogger.Error("Second message", "prop");
        testLogger.Error(new Exception("test"), "Third message");

        // Assert
        testLogger.AssertLogCount(3);
        var entries = testLogger.LogEntries.ToList();
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Error));
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithEmptyString_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error("", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Error_WithWhitespace_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Error("   ", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Error);
        testLogger.AssertLogCount(1);
    }

    #endregion
}