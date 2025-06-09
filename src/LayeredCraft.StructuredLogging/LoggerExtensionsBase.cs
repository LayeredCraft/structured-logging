using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides internal base methods for structured logging operations with performance optimization.
/// </summary>
internal static class LoggerExtensionsBase
{
    /// <summary>
    /// Logs a message at the specified log level with optional exception, checking if logging is enabled first.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    internal static void LogMessage(this ILogger logger, LogLevel logLevel, Exception? exception, string? message)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message);
    }

    /// <summary>
    /// Logs a message at the specified log level with one typed property value, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    internal static void LogMessage<T>(this ILogger logger, LogLevel logLevel, Exception? exception, string? message,
        T? propertyValue)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue });
    }

    /// <summary>
    /// Logs a message at the specified log level with two typed property values, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    internal static void LogMessage<T0, T1>(this ILogger logger, LogLevel logLevel, Exception? exception,
        string? message, T0? propertyValue0, T1? propertyValue1)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue0, propertyValue1 });
    }

    /// <summary>
    /// Logs a message at the specified log level with three typed property values, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    internal static void LogMessage<T0, T1, T2>(this ILogger logger, LogLevel logLevel, Exception? exception,
        string? message, T0? propertyValue0, T1? propertyValue1, T2? propertyValue2)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue0, propertyValue1, propertyValue2 });
    }

    /// <summary>
    /// Logs a message at the specified log level with four typed property values, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    internal static void LogMessage<T0, T1, T2, T3>(this ILogger logger, LogLevel logLevel, Exception? exception,
        string? message, T0? propertyValue0, T1? propertyValue1, T2? propertyValue2, T3? propertyValue3)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue0, propertyValue1, propertyValue2, propertyValue3 });
    }

    /// <summary>
    /// Logs a message at the specified log level with five typed property values, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    internal static void LogMessage<T0, T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, Exception? exception,
        string? message, T0? propertyValue0, T1? propertyValue1, T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4 });
    }

    /// <summary>
    /// Logs a message at the specified log level with six typed property values, checking if logging is enabled first.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <typeparam name="T5">The type of the sixth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level for the message.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="message">The log message.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <param name="propertyValue2">The third property value to include in the log entry.</param>
    /// <param name="propertyValue3">The fourth property value to include in the log entry.</param>
    /// <param name="propertyValue4">The fifth property value to include in the log entry.</param>
    /// <param name="propertyValue5">The sixth property value to include in the log entry.</param>
    internal static void LogMessage<T0, T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, Exception? exception,
        string? message, T0? propertyValue0, T1? propertyValue1, T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        if (logger.IsEnabled(logLevel))
            logger.Log(logLevel, exception, message, new object?[] { propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5 });
    }
}