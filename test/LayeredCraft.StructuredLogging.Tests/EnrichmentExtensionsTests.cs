using Compono.XunitV3;
using LayeredCraft.StructuredLogging.Testing;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests;

public class EnrichmentExtensionsTests
{
    #region LogWithContext Tests

    [Theory]
    [Compose]
    public void LogWithContext_WithStringValue_LogsMessageWithContext(
        string message,
        string contextName,
        string contextValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext(LogLevel.Information, message, contextName, contextValue);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void LogWithContext_WithException_LogsMessageWithContextAndException(
        string message,
        string contextName,
        int contextValue,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext(LogLevel.Error, message, contextName, contextValue, exception);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    [Theory]
    [Compose]
    public void LogWithContext_WithNullMessage_LogsWithContext(
        string contextName,
        bool contextValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext(LogLevel.Warning, null, contextName, contextValue);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
    }

    [Theory]
    [Compose]
    public void LogWithContext_WithComplexObject_LogsWithContext(
        string message,
        string contextName)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        testLogger.LogWithContext(LogLevel.Debug, message, contextName, complexObject);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [Compose]
    public void LogWithContext_WhenLoggerDisabled_DoesNotLog(
        string message,
        string contextName,
        string contextValue)
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        testLogger.LogWithContext(LogLevel.Debug, message, contextName, contextValue);

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Theory]
    [Compose]
    public void LogWithContext_WithNullContextValue_LogsWithContext(
        string message,
        string contextName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext<string?>(LogLevel.Information, message, contextName, null);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region LogWithUserId Tests

    [Theory]
    [Compose]
    public void LogWithUserId_LogsMessageWithUserIdContext(
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithUserId(LogLevel.Information, userId, message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void LogWithUserId_WithException_LogsMessageWithUserIdContextAndException(
        string userId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithUserId(LogLevel.Error, userId, message, exception);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    [Theory]
    [Compose]
    public void LogWithUserId_WithCustomLogLevel_UsesSpecifiedLevel(
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithUserId(LogLevel.Critical, userId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Critical, 1);
        testLogger.AssertLogCount(LogLevel.Information, 0);
    }

    #endregion

    #region LogWithRequestId Tests

    [Theory]
    [Compose]
    public void LogWithRequestId_LogsMessageWithRequestIdContext(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithRequestId(LogLevel.Information, requestId, message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void LogWithRequestId_WithException_LogsMessageWithRequestIdContextAndException(
        string requestId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithRequestId(LogLevel.Warning, requestId, message, exception);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region LogWithCorrelationId Tests

    [Theory]
    [Compose]
    public void LogWithCorrelationId_LogsMessageWithCorrelationIdContext(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithCorrelationId(LogLevel.Information, correlationId, message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void LogWithCorrelationId_WithException_LogsMessageWithCorrelationIdContextAndException(
        string correlationId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithCorrelationId(LogLevel.Error, correlationId, message, exception);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region LogWithCaller Tests

    [Theory]
    [Compose]
    public void LogWithCaller_LogsMessageWithCallerInformation(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithCaller(LogLevel.Debug, message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Debug);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void LogWithCaller_WithException_LogsMessageWithCallerInformationAndException(
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithCaller(LogLevel.Error, message, exception);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    [Fact]
    public void LogWithCaller_WhenLoggerDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Information
        };

        // Act
        testLogger.LogWithCaller(LogLevel.Debug, "test message");

        // Assert
        testLogger.AssertNoLogEntries();
    }

    #endregion

    #region InformationWithUserId Tests

    [Theory]
    [Compose]
    public void InformationWithUserId_LogsInformationLevelMessageWithUserId(
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithUserId(userId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void InformationWithUserId_WithNullMessage_LogsInformationLevel(string userId)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithUserId(userId, null);

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
    }

    #endregion

    #region InformationWithRequestId Tests

    [Theory]
    [Compose]
    public void InformationWithRequestId_LogsInformationLevelMessageWithRequestId(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithRequestId(requestId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    #endregion

    #region InformationWithCorrelationId Tests

    [Theory]
    [Compose]
    public void InformationWithCorrelationId_LogsInformationLevelMessageWithCorrelationId(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithCorrelationId(correlationId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    #endregion

    #region InformationWithCaller Tests

    [Theory]
    [Compose]
    public void InformationWithCaller_LogsInformationLevelMessageWithCallerInfo(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithCaller(message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    #endregion

    #region WarningWithUserId Tests

    [Theory]
    [Compose]
    public void WarningWithUserId_LogsWarningLevelMessageWithUserId(
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithUserId(userId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void WarningWithUserId_WithException_LogsWarningLevelMessageWithUserIdAndException(
        string userId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithUserId(userId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region WarningWithRequestId Tests

    [Theory]
    [Compose]
    public void WarningWithRequestId_LogsWarningLevelMessageWithRequestId(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithRequestId(requestId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void WarningWithRequestId_WithException_LogsWarningLevelMessageWithRequestIdAndException(
        string requestId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithRequestId(requestId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region WarningWithCorrelationId Tests

    [Theory]
    [Compose]
    public void WarningWithCorrelationId_LogsWarningLevelMessageWithCorrelationId(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithCorrelationId(correlationId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void WarningWithCorrelationId_WithException_LogsWarningLevelMessageWithCorrelationIdAndException(
        string correlationId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithCorrelationId(correlationId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region WarningWithCaller Tests

    [Theory]
    [Compose]
    public void WarningWithCaller_LogsWarningLevelMessageWithCallerInfo(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithCaller(message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void WarningWithCaller_WithException_LogsWarningLevelMessageWithCallerInfoAndException(
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.WarningWithCaller(message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Warning);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region ErrorWithUserId Tests

    [Theory]
    [Compose]
    public void ErrorWithUserId_LogsErrorLevelMessageWithUserId(
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithUserId(userId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void ErrorWithUserId_WithException_LogsErrorLevelMessageWithUserIdAndException(
        string userId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithUserId(userId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region ErrorWithRequestId Tests

    [Theory]
    [Compose]
    public void ErrorWithRequestId_LogsErrorLevelMessageWithRequestId(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithRequestId(requestId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void ErrorWithRequestId_WithException_LogsErrorLevelMessageWithRequestIdAndException(
        string requestId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithRequestId(requestId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region ErrorWithCorrelationId Tests

    [Theory]
    [Compose]
    public void ErrorWithCorrelationId_LogsErrorLevelMessageWithCorrelationId(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithCorrelationId(correlationId, message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void ErrorWithCorrelationId_WithException_LogsErrorLevelMessageWithCorrelationIdAndException(
        string correlationId,
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithCorrelationId(correlationId, message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region ErrorWithCaller Tests

    [Theory]
    [Compose]
    public void ErrorWithCaller_LogsErrorLevelMessageWithCallerInfo(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithCaller(message);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().BeNull();
    }

    [Theory]
    [Compose]
    public void ErrorWithCaller_WithException_LogsErrorLevelMessageWithCallerInfoAndException(
        string message,
        string exceptionMessage)
    {
        // Arrange
        var exception = new Exception(exceptionMessage);
        var testLogger = new TestLogger();

        // Act
        testLogger.ErrorWithCaller(message, exception);

        // Assert
        testLogger.AssertLogCount(LogLevel.Error, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.FormattedMessage.Should().Contain(message);
        entry.Exception.Should().Be(exception);
    }

    #endregion

    #region Edge Cases

    [Theory]
    [Compose]
    public void LogWithContext_WithEmptyContextName_LogsCorrectly(
        string message,
        string contextValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext(LogLevel.Information, message, "", contextValue);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [Compose]
    public void LogWithContext_WithWhitespaceContextName_LogsCorrectly(
        string message,
        string contextValue)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.LogWithContext(LogLevel.Information, message, "   ", contextValue);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().Contain(message);
    }

    [Fact]
    public void LogWithUserId_WithEmptyUserId_LogsCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var message = "Test message";

        // Act
        testLogger.LogWithUserId(LogLevel.Information, "", message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().Contain(message);
    }

    [Fact]
    public void LogWithRequestId_WithEmptyRequestId_LogsCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var message = "Test message";

        // Act
        testLogger.LogWithRequestId(LogLevel.Information, "", message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().Contain(message);
    }

    [Fact]
    public void LogWithCorrelationId_WithEmptyCorrelationId_LogsCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var message = "Test message";

        // Act
        testLogger.LogWithCorrelationId(LogLevel.Information, "", message);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().Contain(message);
    }

    [Fact]
    public void InformationWithUserId_WithEmptyMessage_LogsCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var userId = "user123";

        // Act
        testLogger.InformationWithUserId(userId, "");

        // Assert
        testLogger.AssertLogCount(LogLevel.Information, 1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
    }

    [Theory]
    [Compose]
    public void EnrichmentMethods_MultipleCallsInSequence_LogCorrectly(
        string userId,
        string requestId,
        string correlationId,
        string message1,
        string message2,
        string message3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithUserId(userId, message1);
        testLogger.WarningWithRequestId(requestId, message2);
        testLogger.ErrorWithCorrelationId(correlationId, message3);

        // Assert
        testLogger.AssertLogCount(3);
        testLogger.AssertLogCount(LogLevel.Information, 1);
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        testLogger.AssertLogCount(LogLevel.Error, 1);
        
        var entries = testLogger.LogEntries.ToList();
        entries[0].FormattedMessage.Should().Contain(message1);
        entries[1].FormattedMessage.Should().Contain(message2);
        entries[2].FormattedMessage.Should().Contain(message3);
    }

    #endregion
}