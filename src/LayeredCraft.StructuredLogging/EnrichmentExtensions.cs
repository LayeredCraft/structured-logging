using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for enriching log entries with contextual information such as user IDs, request IDs,
/// correlation IDs, and caller information. These methods automatically create scopes and log messages with
/// additional structured data for better observability and debugging.
/// </summary>
public static class EnrichmentExtensions
{
    /// <summary>
    /// Logs a message with additional context information by creating a temporary scope with the specified context property.
    /// </summary>
    /// <typeparam name="T">The type of the context value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="contextName">The name of the context property to add.</param>
    /// <param name="contextValue">The value of the context property to add.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.LogWithContext(LogLevel.Information, "Operation completed", "Duration", duration);
    /// </code>
    /// </example>
    public static void LogWithContext<T>(this ILogger logger, LogLevel logLevel, string? message, string contextName, T contextValue, Exception? exception = null)
    {
        if (logger.IsEnabled(logLevel))
        {
            using var scope = logger.BeginScope(contextName, contextValue);
            logger.Log(logLevel, exception, message);
        }
    }

    /// <summary>
    /// Logs a message with a UserId context property for user-specific operations.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="userId">The user identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.LogWithUserId(LogLevel.Information, "user123", "User login successful");
    /// </code>
    /// </example>
    public static void LogWithUserId(this ILogger logger, LogLevel logLevel, string userId, string? message, Exception? exception = null)
    {
        logger.LogWithContext(logLevel, message, "UserId", userId, exception);
    }

    /// <summary>
    /// Logs a message with a RequestId context property for request-specific operations.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="requestId">The request identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.LogWithRequestId(LogLevel.Warning, "req-456", "Request processing slow");
    /// </code>
    /// </example>
    public static void LogWithRequestId(this ILogger logger, LogLevel logLevel, string requestId, string? message, Exception? exception = null)
    {
        logger.LogWithContext(logLevel, message, "RequestId", requestId, exception);
    }

    /// <summary>
    /// Logs a message with a CorrelationId context property for distributed tracing.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="correlationId">The correlation identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.LogWithCorrelationId(LogLevel.Error, "corr-789", "Service call failed", ex);
    /// </code>
    /// </example>
    public static void LogWithCorrelationId(this ILogger logger, LogLevel logLevel, string correlationId, string? message, Exception? exception = null)
    {
        logger.LogWithContext(logLevel, message, "CorrelationId", correlationId, exception);
    }

    /// <summary>
    /// Logs a message with automatic caller information including method name, file path, and line number.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <example>
    /// <code>
    /// logger.LogWithCaller(LogLevel.Debug, "Method execution completed");
    /// </code>
    /// </example>
    public static void LogWithCaller(this ILogger logger, LogLevel logLevel, string? message, Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (logger.IsEnabled(logLevel))
        {
            using var scope = logger.BeginCallerScope(memberName, filePath, lineNumber);
            logger.Log(logLevel, exception, message);
        }
    }

    /// <summary>
    /// Logs an Information level message with UserId context for user-specific operations.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userId">The user identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.InformationWithUserId("user123", "User profile updated");
    /// </code>
    /// </example>
    public static void InformationWithUserId(this ILogger logger, string userId, string? message)
    {
        logger.LogWithUserId(LogLevel.Information, userId, message);
    }

    /// <summary>
    /// Logs an Information level message with RequestId context for request-specific operations.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="requestId">The request identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.InformationWithRequestId("req-456", "Request processed successfully");
    /// </code>
    /// </example>
    public static void InformationWithRequestId(this ILogger logger, string requestId, string? message)
    {
        logger.LogWithRequestId(LogLevel.Information, requestId, message);
    }

    /// <summary>
    /// Logs an Information level message with CorrelationId context for distributed tracing.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="correlationId">The correlation identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.InformationWithCorrelationId("corr-789", "Service operation completed");
    /// </code>
    /// </example>
    public static void InformationWithCorrelationId(this ILogger logger, string correlationId, string? message)
    {
        logger.LogWithCorrelationId(LogLevel.Information, correlationId, message);
    }

    /// <summary>
    /// Logs an Information level message with automatic caller information.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <example>
    /// <code>
    /// logger.InformationWithCaller("Method execution completed");
    /// </code>
    /// </example>
    public static void InformationWithCaller(this ILogger logger, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogWithCaller(LogLevel.Information, message, null, memberName, filePath, lineNumber);
    }

    /// <summary>
    /// Logs a Warning level message with UserId context for user-specific warnings.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userId">The user identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.WarningWithUserId("user123", "User exceeded rate limit");
    /// </code>
    /// </example>
    public static void WarningWithUserId(this ILogger logger, string userId, string? message, Exception? exception = null)
    {
        logger.LogWithUserId(LogLevel.Warning, userId, message, exception);
    }

    /// <summary>
    /// Logs a Warning level message with RequestId context for request-specific warnings.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="requestId">The request identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.WarningWithRequestId("req-456", "Request took longer than expected");
    /// </code>
    /// </example>
    public static void WarningWithRequestId(this ILogger logger, string requestId, string? message, Exception? exception = null)
    {
        logger.LogWithRequestId(LogLevel.Warning, requestId, message, exception);
    }

    /// <summary>
    /// Logs a Warning level message with CorrelationId context for distributed tracing warnings.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="correlationId">The correlation identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.WarningWithCorrelationId("corr-789", "Service degraded performance");
    /// </code>
    /// </example>
    public static void WarningWithCorrelationId(this ILogger logger, string correlationId, string? message, Exception? exception = null)
    {
        logger.LogWithCorrelationId(LogLevel.Warning, correlationId, message, exception);
    }

    /// <summary>
    /// Logs a Warning level message with automatic caller information.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <example>
    /// <code>
    /// logger.WarningWithCaller("Method execution took longer than expected");
    /// </code>
    /// </example>
    public static void WarningWithCaller(this ILogger logger, string? message, Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogWithCaller(LogLevel.Warning, message, exception, memberName, filePath, lineNumber);
    }

    /// <summary>
    /// Logs an Error level message with UserId context for user-specific errors.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userId">The user identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.ErrorWithUserId("user123", "User authentication failed", authException);
    /// </code>
    /// </example>
    public static void ErrorWithUserId(this ILogger logger, string userId, string? message, Exception? exception = null)
    {
        logger.LogWithUserId(LogLevel.Error, userId, message, exception);
    }

    /// <summary>
    /// Logs an Error level message with RequestId context for request-specific errors.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="requestId">The request identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.ErrorWithRequestId("req-456", "Request processing failed", processingException);
    /// </code>
    /// </example>
    public static void ErrorWithRequestId(this ILogger logger, string requestId, string? message, Exception? exception = null)
    {
        logger.LogWithRequestId(LogLevel.Error, requestId, message, exception);
    }

    /// <summary>
    /// Logs an Error level message with CorrelationId context for distributed tracing errors.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="correlationId">The correlation identifier to include in the log context.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <example>
    /// <code>
    /// logger.ErrorWithCorrelationId("corr-789", "Service call failed", serviceException);
    /// </code>
    /// </example>
    public static void ErrorWithCorrelationId(this ILogger logger, string correlationId, string? message, Exception? exception = null)
    {
        logger.LogWithCorrelationId(LogLevel.Error, correlationId, message, exception);
    }

    /// <summary>
    /// Logs an Error level message with automatic caller information.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <example>
    /// <code>
    /// logger.ErrorWithCaller("Method execution failed", methodException);
    /// </code>
    /// </example>
    public static void ErrorWithCaller(this ILogger logger, string? message, Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogWithCaller(LogLevel.Error, message, exception, memberName, filePath, lineNumber);
    }
}