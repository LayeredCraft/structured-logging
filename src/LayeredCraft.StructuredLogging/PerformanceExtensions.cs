using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for performance monitoring and timing operations in structured logging.
/// These methods help track execution times, monitor performance bottlenecks, and automatically log
/// operation durations with structured data for performance analysis and optimization.
/// </summary>
public static class PerformanceExtensions
{
    /// <summary>
    /// Creates a disposable timer that logs the start and completion time of an operation.
    /// When disposed, it automatically logs the total elapsed time with structured data.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="logLevel">The log level to use for timing messages. Defaults to Information.</param>
    /// <returns>An IDisposable TimedOperation that logs completion time when disposed.</returns>
    /// <example>
    /// <code>
    /// using (logger.TimeOperation("DatabaseQuery"))
    /// {
    ///     // Database operation code here
    ///     // Automatically logs start and completion with elapsed time
    /// }
    /// </code>
    /// </example>
    public static IDisposable TimeOperation(this ILogger logger, string operationName, LogLevel logLevel = LogLevel.Information)
    {
        return new TimedOperation(logger, operationName, logLevel);
    }

    /// <summary>
    /// Executes an asynchronous operation with automatic timing and logging. Logs start, completion, and elapsed time.
    /// If the operation throws an exception, logs the failure with timing information and re-throws the exception.
    /// </summary>
    /// <typeparam name="TResult">The return type of the asynchronous operation.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="operation">The asynchronous operation to execute and time.</param>
    /// <param name="logLevel">The log level to use for success timing messages. Defaults to Information. Errors are always logged at Error level.</param>
    /// <returns>The result of the operation.</returns>
    /// <example>
    /// <code>
    /// var result = await logger.TimeAsync("FetchUserData", async () =>
    /// {
    ///     return await userService.GetUserAsync(userId);
    /// });
    /// </code>
    /// </example>
    public static async Task<TResult> TimeAsync<TResult>(this ILogger logger, string operationName, Func<Task<TResult>> operation, LogLevel logLevel = LogLevel.Information)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogMessage(logLevel, null, "Starting operation: {OperationName}", operationName);
        
        try
        {
            var result = await operation();
            stopwatch.Stop();
            logger.LogMessage(logLevel, null, "Completed operation: {OperationName} in {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            return result;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            logger.LogMessage(LogLevel.Error, ex, "Failed operation: {OperationName} after {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }

    /// <summary>
    /// Executes an asynchronous operation with automatic timing and logging. Logs start, completion, and elapsed time.
    /// If the operation throws an exception, logs the failure with timing information and re-throws the exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="operation">The asynchronous operation to execute and time.</param>
    /// <param name="logLevel">The log level to use for success timing messages. Defaults to Information. Errors are always logged at Error level.</param>
    /// <returns>A task representing the completion of the operation.</returns>
    /// <example>
    /// <code>
    /// await logger.TimeAsync("SendNotification", async () =>
    /// {
    ///     await notificationService.SendAsync(notification);
    /// });
    /// </code>
    /// </example>
    public static async Task TimeAsync(this ILogger logger, string operationName, Func<Task> operation, LogLevel logLevel = LogLevel.Information)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogMessage(logLevel, null, "Starting operation: {OperationName}", operationName);
        
        try
        {
            await operation();
            stopwatch.Stop();
            logger.LogMessage(logLevel, null, "Completed operation: {OperationName} in {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            logger.LogMessage(LogLevel.Error, ex, "Failed operation: {OperationName} after {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }

    /// <summary>
    /// Executes a synchronous operation with automatic timing and logging. Logs start, completion, and elapsed time.
    /// If the operation throws an exception, logs the failure with timing information and re-throws the exception.
    /// </summary>
    /// <typeparam name="TResult">The return type of the operation.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="operation">The synchronous operation to execute and time.</param>
    /// <param name="logLevel">The log level to use for success timing messages. Defaults to Information. Errors are always logged at Error level.</param>
    /// <returns>The result of the operation.</returns>
    /// <example>
    /// <code>
    /// var result = logger.Time("CalculateSum", () =>
    /// {
    ///     return numbers.Sum();
    /// });
    /// </code>
    /// </example>
    public static TResult Time<TResult>(this ILogger logger, string operationName, Func<TResult> operation, LogLevel logLevel = LogLevel.Information)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogMessage(logLevel, null, "Starting operation: {OperationName}", operationName);
        
        try
        {
            var result = operation();
            stopwatch.Stop();
            logger.LogMessage(logLevel, null, "Completed operation: {OperationName} in {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            return result;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            logger.LogMessage(LogLevel.Error, ex, "Failed operation: {OperationName} after {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }

    /// <summary>
    /// Executes a synchronous operation with automatic timing and logging. Logs start, completion, and elapsed time.
    /// If the operation throws an exception, logs the failure with timing information and re-throws the exception.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="operation">The synchronous operation to execute and time.</param>
    /// <param name="logLevel">The log level to use for success timing messages. Defaults to Information. Errors are always logged at Error level.</param>
    /// <example>
    /// <code>
    /// logger.Time("UpdateCache", () =>
    /// {
    ///     cache.Update(data);
    /// });
    /// </code>
    /// </example>
    public static void Time(this ILogger logger, string operationName, Action operation, LogLevel logLevel = LogLevel.Information)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogMessage(logLevel, null, "Starting operation: {OperationName}", operationName);
        
        try
        {
            operation();
            stopwatch.Stop();
            logger.LogMessage(logLevel, null, "Completed operation: {OperationName} in {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            logger.LogMessage(LogLevel.Error, ex, "Failed operation: {OperationName} after {ElapsedMilliseconds}ms", operationName, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }

    /// <summary>
    /// Creates a disposable timer for the current method using automatic caller information.
    /// This is useful for timing method execution without manually specifying the method name.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="logLevel">The log level to use for timing messages. Defaults to Debug.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <returns>An IDisposable TimedOperation that logs method completion time when disposed.</returns>
    /// <example>
    /// <code>
    /// public void ProcessData()
    /// {
    ///     using (logger.TimeMethod())
    ///     {
    ///         // Method implementation
    ///         // Automatically logs "ClassName.ProcessData" timing
    ///     }
    /// }
    /// </code>
    /// </example>
    public static IDisposable TimeMethod(this ILogger logger, LogLevel logLevel = LogLevel.Debug,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "")
    {
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        return new TimedOperation(logger, $"{fileName}.{memberName}", logLevel);
    }
}

/// <summary>
/// Internal class that implements a disposable timer for tracking operation duration.
/// Automatically logs the start time when created and the elapsed time when disposed.
/// </summary>
internal sealed class TimedOperation : IDisposable
{
    private readonly ILogger _logger;
    private readonly string _operationName;
    private readonly LogLevel _logLevel;
    private readonly Stopwatch _stopwatch;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the TimedOperation class and starts timing.
    /// </summary>
    /// <param name="logger">The logger instance to use for logging.</param>
    /// <param name="operationName">The name of the operation being timed.</param>
    /// <param name="logLevel">The log level to use for timing messages.</param>
    public TimedOperation(ILogger logger, string operationName, LogLevel logLevel)
    {
        _logger = logger;
        _operationName = operationName;
        _logLevel = logLevel;
        _stopwatch = Stopwatch.StartNew();
        
        _logger.LogMessage(_logLevel, null, "Starting operation: {OperationName}", _operationName);
    }

    /// <summary>
    /// Stops timing and logs the total elapsed time. Can be called multiple times safely.
    /// </summary>
    public void Dispose()
    {
        if (_disposed) return;
        
        _stopwatch.Stop();
        _logger.LogMessage(_logLevel, null, "Completed operation: {OperationName} in {ElapsedMilliseconds}ms", _operationName, _stopwatch.ElapsedMilliseconds);
        _disposed = true;
    }
}
