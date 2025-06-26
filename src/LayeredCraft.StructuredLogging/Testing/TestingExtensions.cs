using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Testing;

/// <summary>
/// Provides extension methods for testing structured logging functionality. These methods enable
/// easy verification of log entries, searching through log history, and asserting logging behavior
/// in unit tests and integration tests.
/// </summary>
public static class TestingExtensions
{
    /// <summary>
    /// Gets the most recent log entry from the test logger, or null if no entries exist.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <returns>The last log entry, or null if no entries exist.</returns>
    /// <example>
    /// <code>
    /// var lastEntry = testLogger.GetLastLogEntry();
    /// Assert.NotNull(lastEntry);
    /// Assert.Equal(LogLevel.Information, lastEntry.LogLevel);
    /// </code>
    /// </example>
    public static LogEntry? GetLastLogEntry(this TestLogger logger)
    {
        return logger.LogEntries.LastOrDefault();
    }

    /// <summary>
    /// Gets a specific log entry by index, or null if the index is out of range.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="index">The zero-based index of the log entry to retrieve.</param>
    /// <returns>The log entry at the specified index, or null if the index is out of range.</returns>
    /// <example>
    /// <code>
    /// var firstEntry = testLogger.GetLogEntry(0);
    /// var secondEntry = testLogger.GetLogEntry(1);
    /// </code>
    /// </example>
    public static LogEntry? GetLogEntry(this TestLogger logger, int index)
    {
        return index >= 0 && index < logger.LogEntries.Count ? logger.LogEntries[index] : null;
    }

    /// <summary>
    /// Gets all log entries that match the specified log level.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="logLevel">The log level to filter by.</param>
    /// <returns>An enumerable of log entries with the specified log level.</returns>
    /// <example>
    /// <code>
    /// var errorEntries = testLogger.GetLogEntries(LogLevel.Error);
    /// var warningEntries = testLogger.GetLogEntries(LogLevel.Warning);
    /// </code>
    /// </example>
    public static IEnumerable<LogEntry> GetLogEntries(this TestLogger logger, LogLevel logLevel)
    {
        return logger.LogEntries.Where(e => e.LogLevel == logLevel);
    }

    /// <summary>
    /// Gets all log entries whose formatted message contains the specified text.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="message">The text to search for in log messages.</param>
    /// <returns>An enumerable of log entries containing the specified text.</returns>
    /// <example>
    /// <code>
    /// var userEntries = testLogger.GetLogEntriesContaining("user");
    /// var errorEntries = testLogger.GetLogEntriesContaining("failed");
    /// </code>
    /// </example>
    public static IEnumerable<LogEntry> GetLogEntriesContaining(this TestLogger logger, string message)
    {
        return logger.LogEntries.Where(e => e.FormattedMessage?.Contains(message) == true);
    }

    /// <summary>
    /// Gets all log entries that have an associated exception.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <returns>An enumerable of log entries that have exceptions.</returns>
    /// <example>
    /// <code>
    /// var entriesWithExceptions = testLogger.GetLogEntriesWithException();
    /// Assert.True(entriesWithExceptions.Any());
    /// </code>
    /// </example>
    public static IEnumerable<LogEntry> GetLogEntriesWithException(this TestLogger logger)
    {
        return logger.LogEntries.Where(e => e.Exception != null);
    }

    /// <summary>
    /// Gets all log entries that have an exception of the specified type.
    /// </summary>
    /// <typeparam name="TException">The type of exception to filter by.</typeparam>
    /// <param name="logger">The test logger instance.</param>
    /// <returns>An enumerable of log entries that have exceptions of the specified type.</returns>
    /// <example>
    /// <code>
    /// var argumentExceptions = testLogger.GetLogEntriesWithException&lt;ArgumentException&gt;();
    /// var invalidOperationExceptions = testLogger.GetLogEntriesWithException&lt;InvalidOperationException&gt;();
    /// </code>
    /// </example>
    public static IEnumerable<LogEntry> GetLogEntriesWithException<TException>(this TestLogger logger) where TException : Exception
    {
        return logger.LogEntries.Where(e => e.Exception is TException);
    }

    /// <summary>
    /// Checks if the logger has any log entry with the specified log level and optionally containing the specified message.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="logLevel">The log level to search for.</param>
    /// <param name="message">Optional message text to search for within log entries.</param>
    /// <returns>True if a matching log entry is found, false otherwise.</returns>
    /// <example>
    /// <code>
    /// Assert.True(testLogger.HasLogEntry(LogLevel.Error));
    /// Assert.True(testLogger.HasLogEntry(LogLevel.Information, "completed"));
    /// </code>
    /// </example>
    public static bool HasLogEntry(this TestLogger logger, LogLevel logLevel, string? message = null)
    {
        return logger.LogEntries.Any(e => e.LogLevel == logLevel && 
                                         (message == null || e.FormattedMessage?.Contains(message) == true));
    }

    /// <summary>
    /// Checks if the logger has any log entry with an exception of the specified type and optionally with the specified log level.
    /// </summary>
    /// <typeparam name="TException">The type of exception to search for.</typeparam>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="logLevel">Optional log level to filter by.</param>
    /// <returns>True if a matching log entry with the specified exception type is found, false otherwise.</returns>
    /// <example>
    /// <code>
    /// Assert.True(testLogger.HasLogEntryWithException&lt;ArgumentException&gt;());
    /// Assert.True(testLogger.HasLogEntryWithException&lt;InvalidOperationException&gt;(LogLevel.Error));
    /// </code>
    /// </example>
    public static bool HasLogEntryWithException<TException>(this TestLogger logger, LogLevel? logLevel = null) where TException : Exception
    {
        return logger.LogEntries.Any(e => e.Exception is TException && 
                                         (logLevel == null || e.LogLevel == logLevel));
    }

    /// <summary>
    /// Asserts that the most recent log entry has the expected log level and optionally contains the expected message.
    /// Throws an InvalidOperationException if the assertion fails.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="expectedLogLevel">The expected log level of the last entry.</param>
    /// <param name="expectedMessage">Optional expected message text that should be contained in the log entry.</param>
    /// <exception cref="InvalidOperationException">Thrown when no log entries exist or the assertion fails.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertLogEntry(LogLevel.Information);
    /// testLogger.AssertLogEntry(LogLevel.Error, "failed to process");
    /// </code>
    /// </example>
    public static void AssertLogEntry(this TestLogger logger, LogLevel expectedLogLevel, string? expectedMessage = null)
    {
        var entry = logger.GetLastLogEntry();
        if (entry == null)
            throw new InvalidOperationException("No log entries found");

        if (entry.LogLevel != expectedLogLevel)
            throw new InvalidOperationException($"Expected log level {expectedLogLevel}, but was {entry.LogLevel}");

        if (expectedMessage != null && entry.FormattedMessage?.Contains(expectedMessage) != true)
            throw new InvalidOperationException($"Expected message to contain '{expectedMessage}', but was '{entry.FormattedMessage}'");
    }

    /// <summary>
    /// Asserts that the log entry at the specified index has the expected log level and optionally contains the expected message.
    /// Throws an InvalidOperationException if the assertion fails.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="index">The zero-based index of the log entry to check.</param>
    /// <param name="expectedLogLevel">The expected log level of the entry at the specified index.</param>
    /// <param name="expectedMessage">Optional expected message text that should be contained in the log entry.</param>
    /// <exception cref="InvalidOperationException">Thrown when no log entry exists at the index or the assertion fails.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertLogEntryAt(0, LogLevel.Information);
    /// testLogger.AssertLogEntryAt(1, LogLevel.Warning, "rate limit exceeded");
    /// </code>
    /// </example>
    public static void AssertLogEntryAt(this TestLogger logger, int index, LogLevel expectedLogLevel, string? expectedMessage = null)
    {
        var entry = logger.GetLogEntry(index);
        if (entry == null)
            throw new InvalidOperationException($"No log entry found at index {index}");

        if (entry.LogLevel != expectedLogLevel)
            throw new InvalidOperationException($"Expected log level {expectedLogLevel} at index {index}, but was {entry.LogLevel}");

        if (expectedMessage != null && entry.FormattedMessage?.Contains(expectedMessage) != true)
            throw new InvalidOperationException($"Expected message to contain '{expectedMessage}' at index {index}, but was '{entry.FormattedMessage}'");
    }

    /// <summary>
    /// Asserts that the total number of log entries matches the expected count.
    /// Throws an InvalidOperationException if the assertion fails.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="expectedCount">The expected total number of log entries.</param>
    /// <exception cref="InvalidOperationException">Thrown when the actual count doesn't match the expected count.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertLogCount(3); // Expects exactly 3 log entries
    /// testLogger.AssertLogCount(0); // Expects no log entries
    /// </code>
    /// </example>
    public static void AssertLogCount(this TestLogger logger, int expectedCount)
    {
        if (logger.LogEntries.Count != expectedCount)
            throw new InvalidOperationException($"Expected {expectedCount} log entries, but found {logger.LogEntries.Count}");
    }

    /// <summary>
    /// Asserts that the number of log entries with the specified log level matches the expected count.
    /// Throws an InvalidOperationException if the assertion fails.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="logLevel">The log level to filter by.</param>
    /// <param name="expectedCount">The expected number of log entries with the specified log level.</param>
    /// <exception cref="InvalidOperationException">Thrown when the actual count doesn't match the expected count.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertLogCount(LogLevel.Error, 2); // Expects exactly 2 error entries
    /// testLogger.AssertLogCount(LogLevel.Warning, 0); // Expects no warning entries
    /// </code>
    /// </example>
    public static void AssertLogCount(this TestLogger logger, LogLevel logLevel, int expectedCount)
    {
        var count = logger.GetLogEntries(logLevel).Count();
        if (count != expectedCount)
            throw new InvalidOperationException($"Expected {expectedCount} log entries with level {logLevel}, but found {count}");
    }

    /// <summary>
    /// Asserts that the logger has no log entries.
    /// Throws an InvalidOperationException if any log entries exist.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <exception cref="InvalidOperationException">Thrown when log entries exist.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertNoLogEntries(); // Expects the logger to be empty
    /// </code>
    /// </example>
    public static void AssertNoLogEntries(this TestLogger logger)
    {
        logger.AssertLogCount(0);
    }

    /// <summary>
    /// Asserts that the logger has no log entries with the specified log level.
    /// Throws an InvalidOperationException if any log entries with the specified level exist.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <param name="logLevel">The log level to check for absence.</param>
    /// <exception cref="InvalidOperationException">Thrown when log entries with the specified level exist.</exception>
    /// <example>
    /// <code>
    /// testLogger.AssertNoLogEntries(LogLevel.Error); // Expects no error entries
    /// </code>
    /// </example>
    public static void AssertNoLogEntries(this TestLogger logger, LogLevel logLevel)
    {
        logger.AssertLogCount(logLevel, 0);
    }

    /// <summary>
    /// Clears all log entries from the test logger, resetting it to an empty state.
    /// </summary>
    /// <param name="logger">The test logger instance.</param>
    /// <example>
    /// <code>
    /// testLogger.Clear(); // Removes all log entries
    /// testLogger.AssertNoLogEntries(); // Now passes
    /// </code>
    /// </example>
    public static void Clear(this TestLogger logger)
    {
        logger.LogEntries.Clear();
    }
}

/// <summary>
/// A test implementation of ILogger that captures log entries in memory for testing purposes.
/// This allows unit tests to verify logging behavior, check log contents, and assert on log entries.
/// </summary>
public class TestLogger : ILogger
{
    /// <summary>
    /// Gets the collection of all log entries captured by this test logger.
    /// </summary>
    public List<LogEntry> LogEntries { get; } = new();
    /// <summary>
    /// Gets or sets the minimum log level that this logger will capture. Defaults to Trace (captures all levels).
    /// </summary>
    public LogLevel MinimumLogLevel { get; set; } = LogLevel.Trace;

    /// <summary>
    /// Begins a logical operation scope for testing. Returns a test scope that tracks the state.
    /// </summary>
    /// <typeparam name="TState">The type of the state object.</typeparam>
    /// <param name="state">The state object for the scope.</param>
    /// <returns>A disposable test scope.</returns>
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return new TestScope<TState>(state);
    }

    /// <summary>
    /// Determines if the specified log level is enabled based on the MinimumLogLevel setting.
    /// </summary>
    /// <param name="logLevel">The log level to check.</param>
    /// <returns>True if the log level is enabled, false otherwise.</returns>
    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= MinimumLogLevel;
    }

    /// <summary>
    /// Logs an entry if the log level is enabled. Creates a LogEntry and adds it to the LogEntries collection.
    /// </summary>
    /// <typeparam name="TState">The type of the state object.</typeparam>
    /// <param name="logLevel">The log level of the entry.</param>
    /// <param name="eventId">The event identifier for the log entry.</param>
    /// <param name="state">The state object containing the log data.</param>
    /// <param name="exception">The exception associated with the log entry, if any.</param>
    /// <param name="formatter">The function to create the formatted message from state and exception.</param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        var formattedMessage = formatter?.Invoke(state, exception);
        var entry = new LogEntry
        {
            LogLevel = logLevel,
            EventId = eventId,
            State = state,
            Exception = exception,
            FormattedMessage = formattedMessage,
            Timestamp = DateTimeOffset.UtcNow
        };

        LogEntries.Add(entry);
    }
}

/// <summary>
/// Represents a captured log entry from a TestLogger, containing all the information about a single log event.
/// </summary>
public class LogEntry
{
    /// <summary>
    /// Gets or sets the log level of this entry.
    /// </summary>
    public LogLevel LogLevel { get; set; }
    /// <summary>
    /// Gets or sets the event identifier for this log entry.
    /// </summary>
    public EventId EventId { get; set; }
    /// <summary>
    /// Gets or sets the state object that was logged.
    /// </summary>
    public object? State { get; set; }
    /// <summary>
    /// Gets or sets the exception associated with this log entry, if any.
    /// </summary>
    public Exception? Exception { get; set; }
    /// <summary>
    /// Gets or sets the formatted message text for this log entry.
    /// </summary>
    public string? FormattedMessage { get; set; }
    /// <summary>
    /// Gets or sets the timestamp when this log entry was created.
    /// </summary>
    public DateTimeOffset Timestamp { get; set; }
}

/// <summary>
/// A generic test implementation of ILogger&lt;T&gt; that captures log entries in memory for testing purposes.
/// This allows unit tests to verify logging behavior for strongly-typed loggers.
/// </summary>
/// <typeparam name="T">The type being logged for.</typeparam>
public class TestLogger<T> : TestLogger, ILogger<T>
{
    /// <summary>
    /// Initializes a new instance of the TestLogger&lt;T&gt; class.
    /// </summary>
    public TestLogger() : base() { }
}

/// <summary>
/// Internal implementation of a logging scope for testing purposes.
/// Tracks the state object but performs no actual scope management.
/// </summary>
/// <typeparam name="TState">The type of the state object.</typeparam>
internal class TestScope<TState> : IDisposable where TState : notnull
{
    /// <summary>
    /// Gets the state object for this test scope.
    /// </summary>
    public TState State { get; }

    /// <summary>
    /// Initializes a new instance of the TestScope class with the specified state.
    /// </summary>
    /// <param name="state">The state object for this scope.</param>
    public TestScope(TState state)
    {
        State = state;
    }

    /// <summary>
    /// Disposes the test scope. No cleanup is needed for test scopes.
    /// </summary>
    public void Dispose()
    {
        // No cleanup needed for test scope
    }
}