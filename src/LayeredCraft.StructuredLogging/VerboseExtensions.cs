using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for logging verbose-level messages with structured data support.
/// Verbose logging (Trace level) is used for highly detailed diagnostic information that is typically only useful during development and deep troubleshooting.
/// </summary>
public static class VerboseExtensions
{
    /// <summary>
    /// Logs a verbose-level message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Verbose("Method entry: ProcessOrder");
    /// </code>
    /// </example>
    public static void Verbose(this ILogger logger, string? message)
    {
        logger.LogMessage(LogLevel.Trace, null, message);
    }

    /// <summary>
    /// Logs a verbose-level message with one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Verbose("Variable state: counter = {Counter}", counter);
    /// </code>
    /// </example>
    public static void Verbose<T>(this ILogger logger, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Trace, null, message, propertyValue);
    }

    /// <summary>
    /// Logs a verbose-level message with two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Verbose("Loop iteration {Index} processing item {ItemId}", index, itemId);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Trace, null, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a verbose-level message with three typed property values.
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
    /// logger.Verbose("Method {Method} executed with {ParameterCount} parameters in {Duration}ms", methodName, paramCount, duration);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Trace, null, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a verbose-level message with four typed property values.
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
    /// logger.Verbose("Memory allocation: {Size} bytes at {Address} for {Type} in {Region}", size, address, typeName, region);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Trace, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a verbose-level message with five typed property values.
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
    /// logger.Verbose("Network packet {Type} from {Source} to {Destination} size {Size} at {Timestamp}", packetType, source, destination, size, timestamp);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3, T4>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Trace, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a verbose-level message with six typed property values.
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
    /// logger.Verbose("SQL query {Query} on table {Table} in schema {Schema} by user {User} from {Host} took {Duration}ms", query, table, schema, user, host, duration);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3, T4, T5>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Trace, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Verbose(exception, "Exception occurred during detailed processing");
    /// </code>
    /// </example>
    public static void Verbose(this ILogger logger, Exception? exception, string? message)
    {
        logger.LogMessage(LogLevel.Trace, exception, message);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Verbose(exception, "Variable state at exception: counter = {Counter}", counter);
    /// </code>
    /// </example>
    public static void Verbose<T>(this ILogger logger, Exception? exception, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Trace, exception, message, propertyValue);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and two typed property values.
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
    /// logger.Verbose(exception, "Loop failed at iteration {Index} processing item {ItemId}", index, itemId);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Trace, exception, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and three typed property values.
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
    /// logger.Verbose(exception, "Method {Method} failed with {ParameterCount} parameters after {Duration}ms", methodName, paramCount, duration);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Trace, exception, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and four typed property values.
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
    /// logger.Verbose(exception, "Memory allocation failed: {Size} bytes at {Address} for {Type} in {Region}", size, address, typeName, region);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Trace, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and five typed property values.
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
    /// logger.Verbose(exception, "Network packet {Type} send failed from {Source} to {Destination} size {Size} at {Timestamp}", packetType, source, destination, size, timestamp);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3, T4>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Trace, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs a verbose-level message with an associated exception and six typed property values.
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
    /// logger.Verbose(exception, "SQL query {Query} failed on table {Table} in schema {Schema} by user {User} from {Host} after {Duration}ms", query, table, schema, user, host, duration);
    /// </code>
    /// </example>
    public static void Verbose<T0, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Trace, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }
}