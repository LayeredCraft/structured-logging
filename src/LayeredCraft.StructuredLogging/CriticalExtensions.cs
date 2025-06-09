using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for logging critical-level messages with structured data support.
/// Critical logging is used for very serious error events that may cause the application to abort or become unstable.
/// </summary>
public static class CriticalExtensions
{
    /// <summary>
    /// Logs a critical-level message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Critical("Application is shutting down due to critical system failure");
    /// </code>
    /// </example>
    public static void Critical(this ILogger logger, string? message)
    {
        logger.LogMessage(LogLevel.Critical, null, message);
    }

    /// <summary>
    /// Logs a critical-level message with one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Critical("Critical system failure in module {ModuleName}", moduleName);
    /// </code>
    /// </example>
    public static void Critical<T>(this ILogger logger, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Critical, null, message, propertyValue);
    }

    /// <summary>
    /// Logs a critical-level message with two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Critical("Critical database failure on server {ServerName} affecting {UserCount} users", serverName, userCount);
    /// </code>
    /// </example>
    public static void Critical<T0, T1>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Critical, null, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a critical-level message with three typed property values.
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
    /// logger.Critical("Critical system failure: {ServiceName} crashed on {ServerName} affecting {ImpactLevel} operations", serviceName, serverName, impactLevel);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Critical, null, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a critical-level message with four typed property values.
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
    /// logger.Critical("Critical infrastructure failure: {ComponentName} on {ServerName} in {DataCenter} causing {OutageType} outage", componentName, serverName, dataCenter, outageType);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Critical, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a critical-level message with five typed property values.
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
    /// logger.Critical("Critical security breach: {ThreatType} detected on {SystemName} in {Location} affecting {UserCount} users at {Timestamp}", threatType, systemName, location, userCount, timestamp);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3, T4>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Critical, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a critical-level message with six typed property values.
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
    /// logger.Critical("Critical disaster: {DisasterType} in {Region} on {SystemName} affecting {ServiceLevel} services for {UserCount} users since {StartTime}", disasterType, region, systemName, serviceLevel, userCount, startTime);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3, T4, T5>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Critical, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Critical(exception, "Application-wide system failure requiring immediate attention");
    /// </code>
    /// </example>
    public static void Critical(this ILogger logger, Exception? exception, string? message)
    {
        logger.LogMessage(LogLevel.Critical, exception, message);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Critical(exception, "Critical system failure in module {ModuleName}", moduleName);
    /// </code>
    /// </example>
    public static void Critical<T>(this ILogger logger, Exception? exception, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Critical, exception, message, propertyValue);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and two typed property values.
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
    /// logger.Critical(exception, "Critical database failure on server {ServerName} affecting {UserCount} users", serverName, userCount);
    /// </code>
    /// </example>
    public static void Critical<T0, T1>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Critical, exception, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and three typed property values.
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
    /// logger.Critical(exception, "Critical system failure: {ServiceName} crashed on {ServerName} causing {ImpactLevel} impact", serviceName, serverName, impactLevel);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Critical, exception, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and four typed property values.
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
    /// logger.Critical(exception, "Critical infrastructure failure: {ComponentName} on {ServerName} in {DataCenter} causing {OutageType} outage", componentName, serverName, dataCenter, outageType);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Critical, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and five typed property values.
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
    /// logger.Critical(exception, "Critical security breach: {ThreatType} detected on {SystemName} in {Location} affecting {UserCount} users at {Timestamp}", threatType, systemName, location, userCount, timestamp);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3, T4>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Critical, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a critical-level message with an associated exception and six typed property values.
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
    /// logger.Critical(exception, "Critical disaster: {DisasterType} in {Region} on {SystemName} affecting {ServiceLevel} services for {UserCount} users since {StartTime}", disasterType, region, systemName, serviceLevel, userCount, startTime);
    /// </code>
    /// </example>
    public static void Critical<T0, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Critical, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }
}