using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for logging information-level messages with structured data support.
/// Information logging is used for general informational messages that track the application's flow and significant events.
/// </summary>
public static class InformationExtensions
{
    /// <summary>
    /// Logs an information-level message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Information("User logged in successfully");
    /// </code>
    /// </example>
    public static void Information(this ILogger logger, string? message)
    {
        logger.LogMessage(LogLevel.Information, null, message);
    }

    /// <summary>
    /// Logs an information-level message with one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Information("User {UserId} logged in successfully", userId);
    /// </code>
    /// </example>
    public static void Information<T>(this ILogger logger, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Information, null, message, propertyValue);
    }

    /// <summary>
    /// Logs an information-level message with two typed property values.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue0">The first property value to include in the log entry.</param>
    /// <param name="propertyValue1">The second property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Information("Order {OrderId} processed for customer {CustomerId}", orderId, customerId);
    /// </code>
    /// </example>
    public static void Information<T0, T1>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Information, null, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs an information-level message with three typed property values.
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
    /// logger.Information("API request {Method} {Endpoint} completed with status {StatusCode}", method, endpoint, statusCode);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Information, null, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs an information-level message with four typed property values.
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
    /// logger.Information("Payment {PaymentId} of {Amount} {Currency} processed for order {OrderId}", paymentId, amount, currency, orderId);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Information, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs an information-level message with five typed property values.
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
    /// logger.Information("File {FileName} uploaded by user {UserId} to {BucketName} with size {FileSize} and type {ContentType}", fileName, userId, bucketName, fileSize, contentType);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3, T4>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Information, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs an information-level message with six typed property values.
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
    /// logger.Information("Transaction {TransactionId} processed: {Amount} {Currency} from {SourceAccount} to {TargetAccount} at {Timestamp}", transactionId, amount, currency, sourceAccount, targetAccount, timestamp);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3, T4, T5>(this ILogger logger, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Information, null, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message.</param>
    /// <example>
    /// <code>
    /// logger.Information(exception, "Operation completed with warnings");
    /// </code>
    /// </example>
    public static void Information(this ILogger logger, Exception? exception, string? message)
    {
        logger.LogMessage(LogLevel.Information, exception, message);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and one typed property value.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The exception associated with the log entry.</param>
    /// <param name="message">The log message template.</param>
    /// <param name="propertyValue">The property value to include in the log entry.</param>
    /// <example>
    /// <code>
    /// logger.Information(exception, "User {UserId} operation completed with warnings", userId);
    /// </code>
    /// </example>
    public static void Information<T>(this ILogger logger, Exception? exception, string? message, T? propertyValue)
    {
        logger.LogMessage<T>(LogLevel.Information, exception, message, propertyValue);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and two typed property values.
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
    /// logger.Information(exception, "Order {OrderId} processed for customer {CustomerId} with warnings", orderId, customerId);
    /// </code>
    /// </example>
    public static void Information<T0, T1>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1)
    {
        logger.LogMessage<T0, T1>(LogLevel.Information, exception, message, propertyValue0, propertyValue1);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and three typed property values.
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
    /// logger.Information(exception, "API request {Method} {Endpoint} completed with status {StatusCode} and warnings", method, endpoint, statusCode);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2)
    {
        logger.LogMessage<T0, T1, T2>(LogLevel.Information, exception, message, propertyValue0, propertyValue1, propertyValue2);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and four typed property values.
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
    /// logger.Information(exception, "Payment {PaymentId} of {Amount} {Currency} processed for order {OrderId} with warnings", paymentId, amount, currency, orderId);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3)
    {
        logger.LogMessage<T0, T1, T2, T3>(LogLevel.Information, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and five typed property values.
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
    /// logger.Information(exception, "File {FileName} uploaded by user {UserId} to {BucketName} with size {FileSize} and type {ContentType} but with warnings", fileName, userId, bucketName, fileSize, contentType);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3, T4>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4)
    {
        logger.LogMessage<T0, T1, T2, T3, T4>(LogLevel.Information, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4);
    }

    /// <summary>
    /// Logs an information-level message with an associated exception and six typed property values.
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
    /// logger.Information(exception, "Transaction {TransactionId} processed: {Amount} {Currency} from {SourceAccount} to {TargetAccount} at {Timestamp} with warnings", transactionId, amount, currency, sourceAccount, targetAccount, timestamp);
    /// </code>
    /// </example>
    public static void Information<T0, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string? message, T0? propertyValue0, T1? propertyValue1,
        T2? propertyValue2, T3? propertyValue3, T4? propertyValue4, T5? propertyValue5)
    {
        logger.LogMessage<T0, T1, T2, T3, T4, T5>(LogLevel.Information, exception, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3, propertyValue4, propertyValue5);
    }
}