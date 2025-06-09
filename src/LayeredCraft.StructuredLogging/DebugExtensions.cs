using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for logging debug-level messages with structured data support.
/// Debug logging is typically used for detailed diagnostic information that is primarily useful during development and troubleshooting.
/// </summary>
public static class DebugExtensions
{
    /// <summary>
    /// Logs a debug-level message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Processing started");
    /// </code>
    /// </example>
    public static void Debug(this ILogger logger, string? message)
    {
        logger.LogMessage(LogLevel.Debug, null, message);
    }

    /// <summary>
    /// Logs a debug-level message with one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Processing item {ItemId}", itemId);
    /// </code>
    /// </example>
    public static void Debug<T>(this ILogger logger, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Debug, null, message, propertyValue);
    }

    /// <summary>
    /// Logs a debug-level message with two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Processing user {UserId} in tenant {TenantId}", userId, tenantId);
    /// </code>
    /// </example>
    public static void Debug<T0, T1>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Debug, null, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a debug-level message with three typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Query executed in {Duration}ms for user {UserId} returning {Count} results", duration, userId, count);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Debug, null, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a debug-level message with four typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Cache operation {Operation} for key {Key} in region {Region} took {Duration}ms", operation, key, region, duration);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Debug, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a debug-level message with five typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("HTTP request {Method} {Url} by user {UserId} from {IPAddress} took {Duration}ms", method, url, userId, ipAddress, duration);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3, T4>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Debug, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a debug-level message with six typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <typeparam name="T5">The type of the sixth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    /// <param name="propertyValue5">The sixth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug("Database query {Query} on {Database}.{Table} by user {UserId} from {Host} took {Duration}ms with {RowCount} rows", query, database, table, userId, host, duration, rowCount);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3, T4, T5>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Debug, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Failed to process item during debugging");
    /// </code>
    /// </example>
    public static void Debug(this ILogger logger, Exception? exception, string? message)
    {
        logger.LogMessage(LogLevel.Debug, exception, message);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Failed to process item {ItemId}", itemId);
    /// </code>
    /// </example>
    public static void Debug<T>(this ILogger logger, Exception? exception, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Debug, exception, message, propertyValue);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Failed to process user {UserId} in tenant {TenantId}", userId, tenantId);
    /// </code>
    /// </example>
    public static void Debug<T0, T1>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Debug, exception, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and three typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Query failed after {Duration}ms for user {UserId} with {Count} retries", duration, userId, retryCount);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Debug, exception, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and four typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Cache operation {Operation} failed for key {Key} in region {Region} after {Duration}ms", operation, key, region, duration);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Debug, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and five typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "HTTP request {Method} {Url} by user {UserId} from {IPAddress} failed after {Duration}ms", method, url, userId, ipAddress, duration);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3, T4>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Debug, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a debug-level message with an associated exception and six typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <typeparam name="T5">The type of the sixth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    /// <param name="propertyValue5">The sixth property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Debug(exception, "Database query {Query} on {Database}.{Table} by user {UserId} from {Host} failed after {Duration}ms with {RowCount} rows processed", query, database, table, userId, host, duration, rowCount);
    /// </code>
    /// </example>
    public static void Debug<T0, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Debug, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }
}