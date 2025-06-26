using Microsoft.Extensions.Logging;
using LayeredCraft.StructuredLogging.Testing;

namespace LayeredCraft.StructuredLogging.Tests.Testing;

public class GenericTestLoggerTests
{
    private class TestService
    {
    }

    [Fact]
    public void TestLogger_T_ImplementsILogger_T()
    {
        var logger = new TestLogger<TestService>();
        
        logger.Should().BeAssignableTo<ILogger<TestService>>();
        logger.Should().BeAssignableTo<TestLogger>();
    }

    [Fact]
    public void TestLogger_T_CanLogMessages()
    {
        var logger = new TestLogger<TestService>();
        
        logger.LogInformation("Test message");
        
        logger.LogEntries.Should().HaveCount(1);
        logger.LogEntries[0].LogLevel.Should().Be(LogLevel.Information);
        logger.LogEntries[0].FormattedMessage.Should().Be("Test message");
    }

    [Fact]
    public void TestLogger_T_InheritsExtensionMethods()
    {
        var logger = new TestLogger<TestService>();
        
        logger.LogInformation("Test message");
        logger.LogError("Error message");
        
        var lastEntry = logger.GetLastLogEntry();
        lastEntry.Should().NotBeNull();
        lastEntry.LogLevel.Should().Be(LogLevel.Error);
        lastEntry.FormattedMessage.Should().Be("Error message");
        
        var errorEntries = logger.GetLogEntries(LogLevel.Error);
        errorEntries.Should().ContainSingle();
        
        logger.HasLogEntry(LogLevel.Information, "Test message").Should().BeTrue();
        logger.HasLogEntry(LogLevel.Error, "Error message").Should().BeTrue();
        
        logger.LogEntries.Should().HaveCount(2);
        logger.GetLogEntries(LogLevel.Information).Should().ContainSingle();
        logger.GetLogEntries(LogLevel.Error).Should().ContainSingle();
    }

    [Fact]
    public void TestLogger_T_CanClearEntries()
    {
        var logger = new TestLogger<TestService>();
        
        logger.LogInformation("Test message");
        logger.LogEntries.Should().ContainSingle();
        
        logger.Clear();
        logger.LogEntries.Should().BeEmpty();
    }

    [Fact]
    public void TestLogger_T_SharedLogEntriesWithBase()
    {
        var logger = new TestLogger<TestService>();
        TestLogger baseLogger = logger;
        
        logger.LogInformation("From generic logger");
        baseLogger.LogError("From base logger");
        
        logger.LogEntries.Should().HaveCount(2);
        baseLogger.LogEntries.Should().HaveCount(2);
        logger.LogEntries.Should().BeSameAs(baseLogger.LogEntries);
    }

    [Fact]
    public void TestLogger_T_CanBeUsedWhereILogger_T_IsExpected()
    {
        var logger = new TestLogger<TestService>();
        
        // This method expects ILogger<TestService>
        LogWithGenericLogger(logger);
        
        logger.LogEntries.Should().ContainSingle();
        logger.LogEntries[0].FormattedMessage.Should().Be("Generic logger test");
        logger.LogEntries[0].LogLevel.Should().Be(LogLevel.Warning);
    }

    private static void LogWithGenericLogger(ILogger<TestService> logger)
    {
        logger.LogWarning("Generic logger test");
    }
}