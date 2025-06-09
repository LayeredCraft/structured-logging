using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for logging warning-level messages with structured data support.
/// Warning logging is used for potentially harmful situations that do not prevent the application from continuing to run.
/// </summary>
public static class WarningExtensions
{
    /// <summary>
    /// Logs a warning-level message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Warning("Configuration setting is deprecated");
    /// </code>
    /// </example>
    public static void Warning(this ILogger logger, string? message)
    {
        logger.LogMessage(LogLevel.Warning, null, message);
    }

    /// <summary>
    /// Logs a warning-level message with one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Warning("Retry attempt {RetryCount} exceeded recommended limit", retryCount);
    /// </code>
    /// </example>
    public static void Warning<T>(this ILogger logger, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Warning, null, message, propertyValue);
    }

    /// <summary>
    /// Logs a warning-level message with two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Warning("User {UserId} exceeded rate limit of {MaxRequests} requests per minute", userId, maxRequests);
    /// </code>
    /// </example>
    public static void Warning<T0, T1>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Warning, null, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a warning-level message with three typed property values.
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
    /// logger.Warning("API response time {Duration}ms for {Endpoint} exceeded threshold of {Threshold}ms", duration, endpoint, threshold);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Warning, null, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a warning-level message with four typed property values.
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
    /// logger.Warning("Memory usage {CurrentMemory}MB on {ServerName} is approaching limit of {MaxMemory}MB at {Percentage}%", currentMemory, serverName, maxMemory, percentage);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Warning, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a warning-level message with five typed property values.
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
    /// logger.Warning("Queue {QueueName} on {ServerName} has {CurrentSize} items, approaching limit of {MaxSize} with {UsagePercent}% usage", queueName, serverName, currentSize, maxSize, usagePercent);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3, T4>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Warning, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a warning-level message with six typed property values.
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
    /// logger.Warning("Connection pool {PoolName} on {ServerName} in {Region} has {ActiveConnections} active of {MaxConnections} max with {IdleConnections} idle connections", poolName, serverName, region, activeConnections, maxConnections, idleConnections);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3, T4, T5>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Warning, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Warning(exception, "Non-critical operation failed but system continues");
    /// </code>
    /// </example>
    public static void Warning(this ILogger logger, Exception? exception, string? message)
    {
        logger.LogMessage(LogLevel.Warning, exception, message);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Warning(exception, "Retry attempt {RetryCount} failed but will continue", retryCount);
    /// </code>
    /// </example>
    public static void Warning<T>(this ILogger logger, Exception? exception, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Warning, exception, message, propertyValue);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and two typed property values.
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
    /// logger.Warning(exception, "User {UserId} rate limit exceeded with {RequestCount} requests but request allowed", userId, requestCount);
    /// </code>
    /// </example>
    public static void Warning<T0, T1>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Warning, exception, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and three typed property values.
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
    /// logger.Warning(exception, "API timeout after {Duration}ms for {Endpoint} but fallback used with status {StatusCode}", duration, endpoint, statusCode);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Warning, exception, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and four typed property values.
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
    /// logger.Warning(exception, "Memory warning: {CurrentMemory}MB on {ServerName} approaching {MaxMemory}MB limit at {Percentage}%", currentMemory, serverName, maxMemory, percentage);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Warning, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and five typed property values.
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
    /// logger.Warning(exception, "Queue warning: {QueueName} on {ServerName} has {CurrentSize} items approaching {MaxSize} limit with {UsagePercent}% usage", queueName, serverName, currentSize, maxSize, usagePercent);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3, T4>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Warning, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a warning-level message with an associated exception and six typed property values.
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
    /// logger.Warning(exception, "Connection pool warning: {PoolName} on {ServerName} in {Region} has {ActiveConnections} active of {MaxConnections} max with {IdleConnections} idle", poolName, serverName, region, activeConnections, maxConnections, idleConnections);
    /// </code>
    /// </example>
    public static void Warning<T0, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Warning, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }
}