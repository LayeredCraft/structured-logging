using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Test.TestKit.Attributes;
using LayeredCraft.StructuredLogging.Testing;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Test;

public class ScopeExtensionsTests
{
    #region BeginScope With Generic Parameters

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithOneProperty_CreatesScope(
        string name,
        string value)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name, value);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithOneProperty_NullValue_CreatesScope(string name)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope<string?>(name, null);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithTwoProperties_CreatesScope(
        string name0,
        string value0,
        string name1,
        int value1)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name0, value0, name1, value1);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithThreeProperties_CreatesScope(
        string name0,
        string value0,
        string name1,
        int value1,
        string name2,
        bool value2)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name0, value0, name1, value1, name2, value2);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithFourProperties_CreatesScope(
        string name0,
        string value0,
        string name1,
        int value1,
        string name2,
        bool value2,
        string name3,
        double value3)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name0, value0, name1, value1, name2, value2, name3, value3);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithFiveProperties_CreatesScope(
        string name0,
        string value0,
        string name1,
        int value1,
        string name2,
        bool value2,
        string name3,
        double value3,
        string name4,
        long value4)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name0, value0, name1, value1, name2, value2, name3, value3, name4, value4);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithSixProperties_CreatesScope(
        string name0,
        string value0,
        string name1,
        int value1,
        string name2,
        bool value2,
        string name3,
        double value3,
        string name4,
        long value4,
        string name5,
        decimal value5)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope(name0, value0, name1, value1, name2, value2, name3, value3, name4, value4, name5, value5);

        // Assert
        scope.Should().NotBeNull();
    }

    #endregion

    #region BeginScope Integration Tests

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithOneProperty_AllowsLogging(
        string name,
        string value,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginScope(name, value))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithTwoProperties_AllowsLogging(
        string name0,
        string value0,
        string name1,
        int value1,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginScope(name0, value0, name1, value1))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_NestedScopes_AllowsLogging(
        string outerName,
        string outerValue,
        string innerName,
        int innerValue,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginScope(outerName, outerValue))
        {
            using (testLogger.BeginScope(innerName, innerValue))
            {
                testLogger.Information(message);
            }
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region BeginCallerScope Tests

    [Fact]
    public void BeginCallerScope_CreatesScope()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginCallerScope();

        // Assert
        scope.Should().NotBeNull();
    }

    [Fact]
    public void BeginCallerScope_AllowsLogging()
    {
        // Arrange
        var testLogger = new TestLogger();
        var message = "Test message";

        // Act
        using (testLogger.BeginCallerScope())
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginCallerScope_WithProperty_CreatesScope(string name, string value)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginCallerScope<string>(name, value);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginCallerScope_WithProperty_AllowsLogging(
        string name,
        string value,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginCallerScope<string>(name, value))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region BeginRequestScope Tests

    [Theory]
    [AutoNSubstituteData]
    public void BeginRequestScope_WithRequestId_CreatesScope(string requestId)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginRequestScope(requestId);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginRequestScope_WithRequestIdOnly_AllowsLogging(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginRequestScope(requestId))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginRequestScope_WithRequestIdAndUserId_AllowsLogging(
        string requestId,
        string userId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginRequestScope(requestId, userId))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginRequestScope_WithNullUserId_AllowsLogging(
        string requestId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginRequestScope(requestId, null))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region BeginOperationScope Tests

    [Theory]
    [AutoNSubstituteData]
    public void BeginOperationScope_WithOperationName_CreatesScope(string operationName)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginOperationScope(operationName);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginOperationScope_WithOperationNameOnly_AllowsLogging(
        string operationName,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginOperationScope(operationName))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginOperationScope_WithProvidedOperationId_AllowsLogging(
        string operationName,
        string operationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginOperationScope(operationName, operationId))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region BeginCorrelationScope Tests

    [Theory]
    [AutoNSubstituteData]
    public void BeginCorrelationScope_WithCorrelationId_CreatesScope(string correlationId)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginCorrelationScope(correlationId);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginCorrelationScope_WithCorrelationIdOnly_AllowsLogging(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginCorrelationScope(correlationId))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginCorrelationScope_WithCorrelationIdAndParentId_AllowsLogging(
        string correlationId,
        string parentId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginCorrelationScope(correlationId, parentId))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginCorrelationScope_WithNullParentId_AllowsLogging(
        string correlationId,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using (testLogger.BeginCorrelationScope(correlationId, null))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    #endregion

    #region Edge Cases

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WithComplexObjectValue_AllowsLogging(
        string name,
        string message)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new { Name = "Test", Value = 42, Date = DateTime.Now };

        // Act
        using (testLogger.BeginScope(name, complexObject))
        {
            testLogger.Information(message);
        }

        // Assert
        testLogger.AssertLogCount(1);
        var entry = testLogger.GetLastLogEntry();
        entry.Should().NotBeNull();
        entry!.LogLevel.Should().Be(LogLevel.Information);
        entry.FormattedMessage.Should().Contain(message);
    }

    [Fact]
    public void BeginScope_MultipleDispose_DoesNotThrow()
    {
        // Arrange
        var testLogger = new TestLogger();
        var scope = testLogger.BeginScope("test", "value");

        // Act & Assert
        scope.Dispose();
        var action = () => scope.Dispose();
        action.Should().NotThrow();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_EmptyPropertyName_CreatesScope(string value)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope("", value);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScope_WhitespacePropertyName_CreatesScope(string value)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScope("   ", value);

        // Assert
        scope.Should().NotBeNull();
    }

    #endregion

    #region BeginScopeWith

    [Theory]
    [AutoNSubstituteData]
    public void BeginScopeWith_WithAnonymousObject_CreatesScope(
        string userId,
        string sessionId,
        int tenantId)
    {
        // Arrange
        var testLogger = new TestLogger();
        var scopeData = new { UserId = userId, SessionId = sessionId, TenantId = tenantId };

        // Act
        using var scope = testLogger.BeginScopeWith(scopeData);

        // Assert
        scope.Should().NotBeNull();
    }

    [Fact]
    public void BeginScopeWith_WithNull_CreatesScope()
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScopeWith(null!);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScopeWith_WithStringObject_CreatesScope(string message)
    {
        // Arrange
        var testLogger = new TestLogger();

        // Act
        using var scope = testLogger.BeginScopeWith(message);

        // Assert
        scope.Should().NotBeNull();
    }

    [Theory]
    [AutoNSubstituteData]
    public void BeginScopeWith_WithComplexObject_CreatesScope(string name, int age, bool isActive)
    {
        // Arrange
        var testLogger = new TestLogger();
        var complexObject = new 
        { 
            Name = name, 
            Age = age, 
            IsActive = isActive,
            Metadata = new { Source = "Test", Version = 1.0 }
        };

        // Act
        using var scope = testLogger.BeginScopeWith(complexObject);

        // Assert
        scope.Should().NotBeNull();
    }

    #endregion
}