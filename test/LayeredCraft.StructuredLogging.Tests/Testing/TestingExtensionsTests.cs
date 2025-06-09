using AutoFixture.Xunit3;
using AwesomeAssertions;
using LayeredCraft.StructuredLogging.Testing;
using LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests.Testing;

public class TestingExtensionsTests
{
    #region TestLogger Core Functionality Tests

    [Fact]
    public void TestLogger_LogsCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Log(LogLevel.Information, new EventId(1), "Test message", null, (state, ex) => state.ToString());

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Be("Test message");
    }

    [Fact]
    public void TestLogger_WithException_LogsExceptionCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new ArgumentException("Test exception");

        // Act
        testLogger.Log(LogLevel.Error, new EventId(1), "Error message", exception, (state, ex) => state.ToString());

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Error);
        entry.Exception.Should().Be(exception);
        entry.FormattedMessage.Should().Be("Error message");
    }

    [Fact]
    public void TestLogger_WhenDisabled_DoesNotLog()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act
        testLogger.Log(LogLevel.Debug, new EventId(1), "Debug message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Info message", null, (state, ex) => state.ToString());

        // Assert
        testLogger.AssertNoLogEntries();
    }

    [Fact]
    public void TestLogger_LogsTimestampCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var beforeLog = DateTimeOffset.UtcNow;

        // Act
        testLogger.Log(LogLevel.Information, new EventId(1), "Test message", null, (state, ex) => state.ToString());
        var afterLog = DateTimeOffset.UtcNow;

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.Timestamp.Should().BeOnOrAfter(beforeLog);
        entry.Timestamp.Should().BeOnOrBefore(afterLog);
    }

    #endregion

    #region GetLastLogEntry Tests

    [Fact]
    public void GetLastLogEntry_ReturnsLastEntry()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "First message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Second message", null, (state, ex) => state.ToString());

        // Act
        var lastEntry = testLogger.GetLastLogEntry();

        // Assert
        lastEntry.Should().NotBeNull();
        lastEntry!.FormattedMessage.Should().Be("Second message");
        lastEntry.LogLevel.Should().Be(LogLevel.Information);
    }

    [Fact]
    public void GetLastLogEntry_WhenNoEntries_ReturnsNull()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        var lastEntry = testLogger.GetLastLogEntry();

        // Assert
        lastEntry.Should().BeNull();
    }

    [Fact]
    public void GetLastLogEntry_WithSingleEntry_ReturnsThatEntry()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Warning, new EventId(1), "Single message", null, (state, ex) => state.ToString());

        // Act
        var lastEntry = testLogger.GetLastLogEntry();

        // Assert
        lastEntry.Should().NotBeNull();
        lastEntry!.FormattedMessage.Should().Be("Single message");
        lastEntry.LogLevel.Should().Be(LogLevel.Warning);
    }

    #endregion

    #region GetLogEntry Tests

    [Fact]
    public void GetLogEntry_ReturnsCorrectEntryByIndex()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "First message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Second message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(3), "Third message", null, (state, ex) => state.ToString());

        // Act & Assert
        var firstEntry = testLogger.GetLogEntry(0);
        firstEntry.Should().NotBeNull();
        firstEntry!.FormattedMessage.Should().Be("First message");

        var secondEntry = testLogger.GetLogEntry(1);
        secondEntry.Should().NotBeNull();
        secondEntry!.FormattedMessage.Should().Be("Second message");

        var thirdEntry = testLogger.GetLogEntry(2);
        thirdEntry.Should().NotBeNull();
        thirdEntry!.FormattedMessage.Should().Be("Third message");
    }

    [Fact]
    public void GetLogEntry_WithInvalidIndex_ReturnsNull()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message", null, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.GetLogEntry(-1).Should().BeNull();
        testLogger.GetLogEntry(1).Should().BeNull();
        testLogger.GetLogEntry(10).Should().BeNull();
    }

    [Fact]
    public void GetLogEntry_WithEmptyLogger_ReturnsNull()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        var entry = testLogger.GetLogEntry(0);

        // Assert
        entry.Should().BeNull();
    }

    #endregion

    #region GetLogEntries Tests

    [Fact]
    public void GetLogEntries_FiltersCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "Debug message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Info message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(3), "Warning message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(4), "Another info message", null, (state, ex) => state.ToString());

        // Act
        var infoEntries = testLogger.GetLogEntries(LogLevel.Information);

        // Assert
        infoEntries.Should().HaveCount(2);
        infoEntries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(LogLevel.Information));
    }

    [Fact]
    public void GetLogEntries_WithNoMatchingLevel_ReturnsEmpty()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "Debug message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Info message", null, (state, ex) => state.ToString());

        // Act
        var errorEntries = testLogger.GetLogEntries(LogLevel.Error);

        // Assert
        errorEntries.Should().BeEmpty();
    }

    [Theory]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Warning)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Critical)]
    public void GetLogEntries_WithSpecificLevel_ReturnsOnlyThatLevel(LogLevel logLevel)
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "Debug", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Info", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(3), "Warning", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(4), "Error", null, (state, ex) => state.ToString());
        testLogger.Log(logLevel, new EventId(5), "Target", null, (state, ex) => state.ToString());

        // Act
        var entries = testLogger.GetLogEntries(logLevel);

        // Assert
        entries.Should().HaveCountGreaterThan(0);
        entries.Should().AllSatisfy(entry => entry.LogLevel.Should().Be(logLevel));
    }

    #endregion

    #region GetLogEntriesContaining Tests

    [Fact]
    public void GetLogEntriesContaining_FindsMatchingMessages()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "User logged in", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Order processed", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(3), "User logged out", null, (state, ex) => state.ToString());

        // Act
        var userEntries = testLogger.GetLogEntriesContaining("User");

        // Assert
        userEntries.Should().HaveCount(2);
        userEntries.Should().AllSatisfy(entry => entry.FormattedMessage.Should().Contain("User"));
    }

    [Fact]
    public void GetLogEntriesContaining_IsCaseSensitive()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "User logged in", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "user processed", null, (state, ex) => state.ToString());

        // Act
        var upperCaseEntries = testLogger.GetLogEntriesContaining("User");
        var lowerCaseEntries = testLogger.GetLogEntriesContaining("user");

        // Assert
        upperCaseEntries.Should().HaveCount(1);
        lowerCaseEntries.Should().HaveCount(1);
        upperCaseEntries.Should().NotIntersectWith(lowerCaseEntries);
    }

    [Fact]
    public void GetLogEntriesContaining_WithNoMatches_ReturnsEmpty()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "User logged in", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Order processed", null, (state, ex) => state.ToString());

        // Act
        var entries = testLogger.GetLogEntriesContaining("Payment");

        // Assert
        entries.Should().BeEmpty();
    }

    [Fact]
    public void GetLogEntriesContaining_WithNullMessages_HandlesGracefully()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Normal message", null, (state, ex) => state.ToString());
        testLogger.Log<string?>(LogLevel.Information, new EventId(2), null, null, (state, ex) => null);

        // Act
        var entries = testLogger.GetLogEntriesContaining("Normal");

        // Assert
        entries.Should().HaveCount(1);
        entries.First().FormattedMessage.Should().Be("Normal message");
    }

    #endregion

    #region GetLogEntriesWithException Tests

    [Fact]
    public void GetLogEntriesWithException_FindsEntriesWithExceptions()
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception1 = new ArgumentException("Argument error");
        var exception2 = new InvalidOperationException("Operation error");
        
        testLogger.Log(LogLevel.Information, new EventId(1), "Normal message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(2), "Error with exception", exception1, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(3), "Warning with exception", exception2, (state, ex) => state.ToString());

        // Act
        var entriesWithExceptions = testLogger.GetLogEntriesWithException();

        // Assert
        entriesWithExceptions.Should().HaveCount(2);
        entriesWithExceptions.Should().AllSatisfy(entry => entry.Exception.Should().NotBeNull());
    }

    [Fact]
    public void GetLogEntriesWithException_WithNoExceptions_ReturnsEmpty()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message 1", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(2), "Message 2", null, (state, ex) => state.ToString());

        // Act
        var entriesWithExceptions = testLogger.GetLogEntriesWithException();

        // Assert
        entriesWithExceptions.Should().BeEmpty();
    }

    #endregion

    #region GetLogEntriesWithException<T> Tests

    [Fact]
    public void GetLogEntriesWithExceptionT_FindsSpecificExceptionType()
    {
        // Arrange
        var testLogger = new TestLogger();
        var argumentException = new ArgumentException("Argument error");
        var invalidOperationException = new InvalidOperationException("Operation error");
        var notSupportedException = new NotSupportedException("Not supported");
        
        testLogger.Log(LogLevel.Error, new EventId(1), "Error 1", argumentException, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(2), "Error 2", invalidOperationException, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(3), "Error 3", notSupportedException, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(4), "Error 4", new ArgumentException("Another argument error"), (state, ex) => state.ToString());

        // Act
        var argumentExceptions = testLogger.GetLogEntriesWithException<ArgumentException>();
        var operationExceptions = testLogger.GetLogEntriesWithException<InvalidOperationException>();

        // Assert
        argumentExceptions.Should().HaveCount(2);
        argumentExceptions.Should().AllSatisfy(entry => entry.Exception.Should().BeOfType<ArgumentException>());
        
        operationExceptions.Should().HaveCount(1);
        operationExceptions.Should().AllSatisfy(entry => entry.Exception.Should().BeOfType<InvalidOperationException>());
    }

    [Fact]
    public void GetLogEntriesWithExceptionT_WithNoMatchingType_ReturnsEmpty()
    {
        // Arrange
        var testLogger = new TestLogger();
        var argumentException = new ArgumentException("Argument error");
        
        testLogger.Log(LogLevel.Error, new EventId(1), "Error", argumentException, (state, ex) => state.ToString());

        // Act
        var operationExceptions = testLogger.GetLogEntriesWithException<InvalidOperationException>();

        // Assert
        operationExceptions.Should().BeEmpty();
    }

    #endregion

    #region HasLogEntry Tests

    [Fact]
    public void HasLogEntry_ReturnsTrueWhenEntryExists()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Error, new EventId(1), "Error occurred", null, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.HasLogEntry(LogLevel.Error).Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Error, "Error occurred").Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Warning).Should().BeFalse();
    }

    [Fact]
    public void HasLogEntry_WithMessageFilter_FindsPartialMatches()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "User logged in successfully", null, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.HasLogEntry(LogLevel.Information, "User").Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Information, "logged in").Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Information, "successfully").Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Information, "failed").Should().BeFalse();
    }

    [Fact]
    public void HasLogEntry_WithWrongLogLevel_ReturnsFalse()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "User logged in", null, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.HasLogEntry(LogLevel.Error, "User logged in").Should().BeFalse();
    }

    #endregion

    #region HasLogEntryWithException<T> Tests

    [Fact]
    public void HasLogEntryWithExceptionT_FindsCorrectExceptionType()
    {
        // Arrange
        var testLogger = new TestLogger();
        var argumentException = new ArgumentException("Argument error");
        
        testLogger.Log(LogLevel.Error, new EventId(1), "Error", argumentException, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.HasLogEntryWithException<ArgumentException>().Should().BeTrue();
        testLogger.HasLogEntryWithException<InvalidOperationException>().Should().BeFalse();
    }

    [Fact]
    public void HasLogEntryWithExceptionT_WithLogLevelFilter_FiltersCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        var argumentException = new ArgumentException("Argument error");
        
        testLogger.Log(LogLevel.Warning, new EventId(1), "Warning", argumentException, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(2), "Error", argumentException, (state, ex) => state.ToString());

        // Act & Assert
        testLogger.HasLogEntryWithException<ArgumentException>(LogLevel.Error).Should().BeTrue();
        testLogger.HasLogEntryWithException<ArgumentException>(LogLevel.Warning).Should().BeTrue();
        testLogger.HasLogEntryWithException<ArgumentException>(LogLevel.Critical).Should().BeFalse();
    }

    #endregion

    #region AssertLogEntry Tests

    [Fact]
    public void AssertLogEntry_WithValidEntry_Succeeds()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Test message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntry(LogLevel.Information);
        action.Should().NotThrow();
    }

    [Fact]
    public void AssertLogEntry_WithValidEntryAndMessage_Succeeds()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Warning, new EventId(1), "Warning: rate limit exceeded", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntry(LogLevel.Warning, "rate limit");
        action.Should().NotThrow();
    }

    [Fact]
    public void AssertLogEntry_ThrowsWhenNoEntries()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act & Assert
        var action = () => testLogger.AssertLogEntry(LogLevel.Information);
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("No log entries found");
    }

    [Fact]
    public void AssertLogEntry_ThrowsWhenLogLevelMismatch()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Info message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntry(LogLevel.Error);
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Expected log level Error, but was Information");
    }

    [Fact]
    public void AssertLogEntry_ThrowsWhenMessageMismatch()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Actual message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntry(LogLevel.Information, "Expected message");
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Expected message to contain 'Expected message', but was 'Actual message'");
    }

    #endregion

    #region AssertLogEntryAt Tests

    [Fact]
    public void AssertLogEntryAt_WithValidIndex_Succeeds()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Debug, new EventId(1), "First message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Second message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action1 = () => testLogger.AssertLogEntryAt(0, LogLevel.Debug, "First");
        var action2 = () => testLogger.AssertLogEntryAt(1, LogLevel.Information, "Second");
        
        action1.Should().NotThrow();
        action2.Should().NotThrow();
    }

    [Fact]
    public void AssertLogEntryAt_WithInvalidIndex_Throws()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntryAt(1, LogLevel.Information);
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("No log entry found at index 1");
    }

    [Fact]
    public void AssertLogEntryAt_WithWrongLogLevel_Throws()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertLogEntryAt(0, LogLevel.Error);
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Expected log level Error at index 0, but was Information");
    }

    #endregion

    #region AssertLogCount Tests

    [Fact]
    public void AssertLogCount_ValidatesCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message 1", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Message 2", null, (state, ex) => state.ToString());

        // Act & Assert
        var action1 = () => testLogger.AssertLogCount(2);
        var action2 = () => testLogger.AssertLogCount(LogLevel.Information, 2);
        var action3 = () => testLogger.AssertLogCount(3);
        
        action1.Should().NotThrow();
        action2.Should().NotThrow();
        action3.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void AssertLogCount_WithSpecificLogLevel_ValidatesCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Info 1", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(2), "Warning 1", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(3), "Info 2", null, (state, ex) => state.ToString());

        // Act & Assert
        var action1 = () => testLogger.AssertLogCount(LogLevel.Information, 2);
        var action2 = () => testLogger.AssertLogCount(LogLevel.Warning, 1);
        var action3 = () => testLogger.AssertLogCount(LogLevel.Error, 0);
        var action4 = () => testLogger.AssertLogCount(LogLevel.Information, 3);
        
        action1.Should().NotThrow();
        action2.Should().NotThrow();
        action3.Should().NotThrow();
        action4.Should().Throw<InvalidOperationException>();
    }

    #endregion

    #region AssertNoLogEntries Tests

    [Fact]
    public void AssertNoLogEntries_WithEmptyLogger_Succeeds()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act & Assert
        var action = () => testLogger.AssertNoLogEntries();
        action.Should().NotThrow();
    }

    [Fact]
    public void AssertNoLogEntries_WithEntries_Throws()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action = () => testLogger.AssertNoLogEntries();
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void AssertNoLogEntries_WithSpecificLogLevel_ValidatesCorrectly()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Info message", null, (state, ex) => state.ToString());

        // Act & Assert
        var action1 = () => testLogger.AssertNoLogEntries(LogLevel.Error);
        var action2 = () => testLogger.AssertNoLogEntries(LogLevel.Information);
        
        action1.Should().NotThrow();
        action2.Should().Throw<InvalidOperationException>();
    }

    #endregion

    #region Clear Tests

    [Fact]
    public void Clear_RemovesAllEntries()
    {
        // Arrange
        var testLogger = new TestLogger();
        testLogger.Log(LogLevel.Information, new EventId(1), "Message 1", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(2), "Message 2", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(3), "Message 3", null, (state, ex) => state.ToString());

        // Act
        testLogger.Clear();

        // Assert
        testLogger.AssertNoLogEntries();
        testLogger.LogEntries.Should().BeEmpty();
        testLogger.GetLastLogEntry().Should().BeNull();
    }

    [Fact]
    public void Clear_WithEmptyLogger_DoesNotThrow()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act & Assert
        var action = () => testLogger.Clear();
        action.Should().NotThrow();
        testLogger.AssertNoLogEntries();
    }

    #endregion

    #region IsEnabled Tests

    [Fact]
    public void IsEnabled_RespectsMinimumLogLevel()
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = LogLevel.Warning
        };

        // Act & Assert
        testLogger.IsEnabled(LogLevel.Trace).Should().BeFalse();
        testLogger.IsEnabled(LogLevel.Debug).Should().BeFalse();
        testLogger.IsEnabled(LogLevel.Information).Should().BeFalse();
        testLogger.IsEnabled(LogLevel.Warning).Should().BeTrue();
        testLogger.IsEnabled(LogLevel.Error).Should().BeTrue();
        testLogger.IsEnabled(LogLevel.Critical).Should().BeTrue();
        testLogger.IsEnabled(LogLevel.None).Should().BeTrue();
    }

    [Theory]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Warning)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Critical)]
    public void IsEnabled_WithSpecificMinimumLevel_WorksCorrectly(LogLevel minimumLevel)
    {
        // Arrange
        var testLogger = new TestLogger
        {
            MinimumLogLevel = minimumLevel
        };

        // Act & Assert
        foreach (LogLevel level in Enum.GetValues<LogLevel>())
        {
            if (level == LogLevel.None) continue;
            
            var expected = level >= minimumLevel;
            testLogger.IsEnabled(level).Should().Be(expected, 
                $"LogLevel.{level} should be {(expected ? "enabled" : "disabled")} when minimum is {minimumLevel}");
        }
    }

    #endregion

    #region BeginScope Tests

    [Fact]
    public void BeginScope_ReturnsDisposableScope()
    {
        // Arrange
        var testLogger = new TestLogger();
        var state = new { Property = "Value" };

        // Act
        using var scope = testLogger.BeginScope(state);

        // Assert
        scope.Should().NotBeNull();
        scope.Should().BeAssignableTo<IDisposable>();
    }

    [Fact]
    public void BeginScope_WithStringState_CreatesScope()
    {
        // Arrange
        var testLogger = new TestLogger();
        var state = "Test scope state";

        // Act
        using var scope = testLogger.BeginScope(state);

        // Assert
        scope.Should().NotBeNull();
    }

    [Fact]
    public void BeginScope_WithNullState_CreatesScope()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope("test-scope");

        // Assert
        scope.Should().NotBeNull();
    }

    [Fact]
    public void BeginScope_MultipleDispose_DoesNotThrow()
    {
        // Arrange
        var testLogger = new TestLogger();
        var scope = testLogger.BeginScope("test");

        // Act & Assert
        scope?.Dispose();
        var action = () => scope?.Dispose();
        action.Should().NotThrow();
    }

    #endregion

    #region Integration Tests

    [Theory]
    [AutoNSubstituteData]
    public void TestLogger_IntegrationTest_WorksWithStructuredLoggingExtensions(
        string userId,
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.InformationWithUserId(userId, message);
        testLogger.WarningWithRequestId(requestId, "Warning message");
        testLogger.ErrorWithCorrelationId("corr-123", "Error message");

        // Assert
        testLogger.AssertLogCount(3);
        testLogger.AssertLogCount(LogLevel.Information, 1);
        testLogger.AssertLogCount(LogLevel.Warning, 1);
        testLogger.AssertLogCount(LogLevel.Error, 1);
        
        testLogger.HasLogEntry(LogLevel.Information, message).Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Warning, "Warning").Should().BeTrue();
        testLogger.HasLogEntry(LogLevel.Error, "Error").Should().BeTrue();
    }

    [Fact]
    public void TestLogger_ComplexScenario_AllMethodsWork()
    {
        // Arrange
        var testLogger = new TestLogger();
        var exception = new InvalidOperationException("Test exception");

        // Act - Log various entries
        testLogger.Log(LogLevel.Debug, new EventId(1), "Debug message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Information, new EventId(2), "Info message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Warning, new EventId(3), "Warning message", null, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Error, new EventId(4), "Error message", exception, (state, ex) => state.ToString());
        testLogger.Log(LogLevel.Critical, new EventId(5), "Critical message", null, (state, ex) => state.ToString());

        // Assert - Test all extension methods
        testLogger.AssertLogCount(5);
        testLogger.GetLastLogEntry()!.LogLevel.Should().Be(LogLevel.Critical);
        testLogger.GetLogEntry(0)!.LogLevel.Should().Be(LogLevel.Debug);
        testLogger.GetLogEntries(LogLevel.Warning).Should().HaveCount(1);
        testLogger.GetLogEntriesContaining("Info").Should().HaveCount(1);
        testLogger.GetLogEntriesWithException().Should().HaveCount(1);
        testLogger.GetLogEntriesWithException<InvalidOperationException>().Should().HaveCount(1);
        testLogger.HasLogEntry(LogLevel.Error).Should().BeTrue();
        testLogger.HasLogEntryWithException<InvalidOperationException>().Should().BeTrue();
        
        // Clear and verify
        testLogger.Clear();
        testLogger.AssertNoLogEntries();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void TestLogger_WithNullFormatter_HandlesGracefully()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        testLogger.Log(LogLevel.Information, new EventId(1), "Test", null, null!);

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.FormattedMessage.Should().BeNull();
    }

    [Fact]
    public void TestLogger_WithCustomEventId_PreservesEventId()
    {
        // Arrange
        var testLogger = new TestLogger();
        var eventId = new EventId(42, "CustomEvent");

        // Act
        testLogger.Log(LogLevel.Information, eventId, "Test message", null, (state, ex) => state.ToString());

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.EventId.Should().Be(eventId);
        entry.EventId.Id.Should().Be(42);
        entry.EventId.Name.Should().Be("CustomEvent");
    }

    [Fact]
    public void TestLogger_WithComplexState_PreservesState()
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexState = new { UserId = "user123", Action = "Login", Timestamp = DateTime.Now };

        // Act
        testLogger.Log(LogLevel.Information, new EventId(1), complexState, null, (state, ex) => state.ToString());

        // Assert
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.State.Should().Be(complexState);
    }

    #endregion
}