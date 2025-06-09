using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class WarningExtensionsTests
{
    #region Warning Methods Without Exception
    
    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithMessage_LogsAtWarningLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(message);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning, message);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Warning_WithNullMessage_LogsAtWarningLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithOneProperty_LogsAtWarningLevel(
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(message, propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithOneProperty_NullValue_LogsAtWarningLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning<string?>(message, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithTwoProperties_LogsAtWarningLevel(
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(message, prop0, prop1);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithThreeProperties_LogsAtWarningLevel(
        string message,
        string prop0,
        int prop1, 
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(message, prop0, prop1, prop2);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithFourProperties_LogsAtWarningLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(message, prop0, prop1, prop2, prop3);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithFiveProperties_LogsAtWarningLevel(
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
        testLogger.Warning(message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithSixProperties_LogsAtWarningLevel(
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
        testLogger.Warning(message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Warning Methods With Exception

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithMessageAndException_LogsAtWarningLevelWithException(
        string message,
        Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(exception, message);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Contain(message);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithNullMessageAndException_LogsAtWarningLevel(Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(exception, null);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndOneProperty_LogsAtWarningLevel(
        Exception exception,
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(exception, message, propertyValue);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndTwoProperties_LogsAtWarningLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(exception, message, prop0, prop1);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndThreeProperties_LogsAtWarningLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning(exception, message, prop0, prop1, prop2);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndFourProperties_LogsAtWarningLevel(
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
        testLogger.Warning(exception, message, prop0, prop1, prop2, prop3);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndFiveProperties_LogsAtWarningLevel(
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
        testLogger.Warning(exception, message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithExceptionAndSixProperties_LogsAtWarningLevel(
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
        testLogger.Warning(exception, message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Logger State Tests

    [Fact]
    public void Warning_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Error
        };

        // Act
        testLogger.Warning("test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Warning_WhenLoggerDisabledWithException_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Error
        };
        var exception = new InvalidOperationException("test");

        // Act
        testLogger.Warning(exception, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Warning_WhenLoggerDisabledWithProperties_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Error
        };

        // Act
        testLogger.Warning("test message", "prop1", 42, true);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Warning_WhenLoggerEnabled_Logs()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        testLogger.Warning("test message");

        // Assert
        testLogger.AssertLogCount(1);
        testLogger.AssertLogEntry(LogLevel.Warning, "test message");
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithComplexObjectProperty_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.Warning(message, complexObject);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithMixedNullAndValueProperties_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning<string?, int?, bool?>(message, null, 42, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Warning_MultipleCallsInSequence_LogsAll()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning("First message");
        testLogger.Warning("Second message", "prop");
        testLogger.Warning(new Exception("test"), "Third message");

        // Assert
        testLogger.AssertLogCount(3);
        var entries = testLogger.LogEntries.ToList();
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Warning));
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithEmptyString_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning("", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Warning_WithWhitespace_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Warning("   ", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Warning);
        testLogger.AssertLogCount(1);
    }

    #endregion
}