using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class InformationExtensionsTests
{
    #region Information Methods Without Exception
    
    [Theory]
    [AutoNSubstituteData]
    public void Information_WithMessage_LogsAtInformationLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(message);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information, message);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Information_WithNullMessage_LogsAtInformationLevel()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithOneProperty_LogsAtInformationLevel(
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(message, propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithOneProperty_NullValue_LogsAtInformationLevel(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information<string?>(message, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithTwoProperties_LogsAtInformationLevel(
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(message, prop0, prop1);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithThreeProperties_LogsAtInformationLevel(
        string message,
        string prop0,
        int prop1, 
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(message, prop0, prop1, prop2);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithFourProperties_LogsAtInformationLevel(
        string message,
        string prop0,
        int prop1,
        bool prop2,
        double prop3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(message, prop0, prop1, prop2, prop3);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithFiveProperties_LogsAtInformationLevel(
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
        testLogger.Information(message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithSixProperties_LogsAtInformationLevel(
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
        testLogger.Information(message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Information Methods With Exception

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithMessageAndException_LogsAtInformationLevelWithException(
        string message,
        Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(exception, message);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Contain(message);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithNullMessageAndException_LogsAtInformationLevel(Exception exception)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(exception, null);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndOneProperty_LogsAtInformationLevel(
        Exception exception,
        string message,
        string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(exception, message, propertyValue);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndTwoProperties_LogsAtInformationLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(exception, message, prop0, prop1);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndThreeProperties_LogsAtInformationLevel(
        Exception exception,
        string message,
        string prop0,
        int prop1,
        bool prop2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information(exception, message, prop0, prop1, prop2);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndFourProperties_LogsAtInformationLevel(
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
        testLogger.Information(exception, message, prop0, prop1, prop2, prop3);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndFiveProperties_LogsAtInformationLevel(
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
        testLogger.Information(exception, message, prop0, prop1, prop2, prop3, prop4);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithExceptionAndSixProperties_LogsAtInformationLevel(
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
        testLogger.Information(exception, message, prop0, prop1, prop2, prop3, prop4, prop5);

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.Exception.Should().Be(exception);
        testLogger.AssertLogCount(1);
    }

    #endregion

    #region Logger State Tests

    [Fact]
    public void Information_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        testLogger.Information("test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Information_WhenLoggerDisabledWithException_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };
        var exception = new InvalidOperationException("test");

        // Act
        testLogger.Information(exception, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Information_WhenLoggerDisabledWithProperties_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        testLogger.Information("test message", "prop1", 42, true);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void Information_WhenLoggerEnabled_Logs()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };

        // Act
        testLogger.Information("test message");

        // Assert
        testLogger.AssertLogCount(1);
        testLogger.AssertLogEntry(LogLevel.Information, "test message");
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithComplexObjectProperty_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.Information(message, complexObject);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithMixedNullAndValueProperties_LogsCorrectly(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information<string?, int?, bool?>(message, null, 42, null);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Fact]
    public void Information_MultipleCallsInSequence_LogsAll()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information("First message");
        testLogger.Information("Second message", "prop");
        testLogger.Information(new Exception("test"), "Third message");

        // Assert
        testLogger.AssertLogCount(3);
        var entries = testLogger.LogEntries.ToList();
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Information));
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithEmptyString_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information("", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    [Theory]
    [AutoNSubstituteData]
    public void Information_WithWhitespace_LogsCorrectly(string propertyValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Information("   ", propertyValue);

        // Assert
        testLogger.AssertLogEntry(LogLevel.Information);
        testLogger.AssertLogCount(1);
    }

    #endregion
}