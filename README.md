# LayeredCraft.StructuredLogging

[![Build Status](https://github.com/LayeredCraft/structured-logging/actions/workflows/build.yaml/badge.svg)](https://github.com/LayeredCraft/structured-logging/actions/workflows/build.yaml)
[![NuGet](https://img.shields.io/nuget/v/LayeredCraft.StructuredLogging.svg)](https://www.nuget.org/packages/LayeredCraft.StructuredLogging/)
[![Downloads](https://img.shields.io/nuget/dt/LayeredCraft.StructuredLogging.svg)](https://www.nuget.org/packages/LayeredCraft.StructuredLogging/)

Simplified, structured logging for modern .NET apps — overloads, conditionals, and performance built-in.

## Features

- 🚀 **High Performance** - Built-in level checks and efficient parameter handling
- 📊 **Structured Logging** - Rich contextual data with strongly-typed parameters
- 🔧 **Easy Integration** - Drop-in replacement for standard ILogger calls
- 🎯 **Scope Management** - Comprehensive scope tracking with automatic disposal
- ⚡ **Performance Monitoring** - Built-in timing and performance tracking
- 🧪 **Testing Support** - Complete testing framework with assertions and mocking
- 📦 **Multi-Target** - Supports .NET 8.0, .NET 9.0, and .NET Standard 2.1

## Installation

```bash
dotnet add package LayeredCraft.StructuredLogging
```

## Quick Start

```csharp
using LayeredCraft.StructuredLogging;
using Microsoft.Extensions.Logging;

// Basic logging
logger.Information("User logged in successfully");
logger.Warning("Rate limit exceeded for user {UserId}", userId);
logger.Error(exception, "Failed to process order {OrderId}", orderId);

// Structured logging with multiple parameters
logger.Information("Order processed for user {UserId} with total {Total:C}", 
    userId, orderTotal);

// Performance monitoring
using (logger.TimeOperation("Database operation"))
{
    // Your database code here
} // Automatically logs execution time

// Enriched logging with context
logger.LogWithContext(LogLevel.Information, "Starting order processing", "UserId", userId);
logger.InformationWithUserId(userId, "Order processing started");
```

## Core Extensions

### Log Level Extensions

All standard log levels are supported with convenient extension methods:

```csharp
// Debug logging
logger.Debug("Debug information");
logger.Debug("Processing item {ItemId}", itemId);

// Verbose/Trace logging
logger.Verbose("Detailed trace information");
logger.Verbose("Entering method {MethodName}", methodName);

// Information logging
logger.Information("Operation completed successfully");
logger.Information("User {UserId} performed action {Action}", userId, action);

// Warning logging
logger.Warning("Performance threshold exceeded");
logger.Warning("Retry attempt {AttemptNumber} for operation {OperationId}", 
    attemptNumber, operationId);

// Error logging
logger.Error("Operation failed");
logger.Error(exception, "Failed to save entity {EntityId}", entityId);

// Critical logging
logger.Critical("System is in critical state");
logger.Critical(exception, "Database connection lost");
```

### Scope Management

Create logging scopes for better context tracking:

```csharp
// Simple scopes
using (logger.BeginScope("UserRegistration"))
{
    logger.Information("Starting user registration");
    // Registration logic
}

// Structured scopes with properties
using (logger.BeginScope("OrderId", orderId))
{
    logger.Information("Processing order");
    // Order processing logic
}

// Complex scopes with multiple properties
using (logger.BeginScopeWith(new { UserId = userId, SessionId = sessionId }))
{
    logger.Information("User session started");
    // Session logic
}

// Timed scopes for performance monitoring
using (logger.TimeOperation("DatabaseQuery"))
{
    // Database operation
} // Automatically logs execution time
```

### Enrichment

Add contextual information to log entries:

```csharp
// Context-specific logging methods
logger.LogWithUserId(LogLevel.Information, userId, "User operation completed");
logger.LogWithRequestId(LogLevel.Information, requestId, "Request processed");
logger.LogWithCorrelationId(LogLevel.Information, correlationId, "Service call completed");

// Convenience methods for common log levels
logger.InformationWithUserId(userId, "User profile updated");
logger.WarningWithRequestId(requestId, "Request took longer than expected");
logger.ErrorWithCorrelationId(correlationId, "Service call failed", exception);

// Custom context enrichment
logger.LogWithContext(LogLevel.Information, "Operation completed", "Duration", duration);
logger.LogWithContext(LogLevel.Warning, "Rate limit approaching", "UserId", userId);

// Automatic caller information
logger.LogWithCaller(LogLevel.Debug, "Method execution completed");
logger.InformationWithCaller("Operation finished successfully");
```

### Performance Monitoring

Built-in performance tracking capabilities:

```csharp
// Timed operations
using (logger.TimeOperation("DatabaseQuery"))
{
    // Your database code
} // Logs: "DatabaseQuery completed in 150ms"

// Synchronous timed operations
var result = logger.Time("CalculateSum", () =>
{
    return numbers.Sum();
});

// Asynchronous timed operations
await logger.TimeAsync("FetchUserData", async () =>
{
    await userService.GetUserAsync(userId);
});

// Method-level timing with caller info
using (logger.TimeMethod())
{
    // Current method is automatically timed
}
```

## Testing Support

Comprehensive testing framework for verifying logging behavior:

```csharp
[Test]
public void Should_Log_User_Registration()
{
    // Arrange
    var testLogger = new TestLogger();
    var userService = new UserService(testLogger);

    // Act
    userService.RegisterUser("john@example.com");

    // Assert
    testLogger.Should().HaveLoggedInformation()
        .WithMessage("User registered successfully")
        .WithProperty("Email", "john@example.com");

    // Alternative assertion syntax
    testLogger.AssertLogEntry(LogLevel.Information, "User registered");
    testLogger.AssertLogCount(1);
    testLogger.Should().HaveExactly(1).LogEntries();
}

[Test]
public void Should_Handle_Registration_Errors()
{
    // Arrange
    var testLogger = new TestLogger();
    var userService = new UserService(testLogger);

    // Act & Assert
    Assert.Throws<ValidationException>(() => 
        userService.RegisterUser("invalid-email"));

    testLogger.Should().HaveLoggedError()
        .WithException<ValidationException>()
        .WithMessage("Invalid email format");
}
```

### TestLogger Features

```csharp
// Get specific log entries
var lastEntry = testLogger.GetLastLogEntry();
var errorEntries = testLogger.GetLogEntries(LogLevel.Error);
var entriesWithException = testLogger.GetLogEntriesWithException<ArgumentException>();

// Search log entries
var userEntries = testLogger.GetLogEntriesContaining("user");
var hasError = testLogger.HasLogEntry(LogLevel.Error, "failed");

// Assertions
testLogger.AssertLogCount(5);
testLogger.AssertLogEntry(LogLevel.Information, "expected message");
testLogger.AssertNoLogEntries(LogLevel.Error);

// Clear logs between tests
testLogger.Clear();
```

## Advanced Usage

### Conditional Logging

All logging methods include built-in level checks for optimal performance:

```csharp
// These methods automatically check if the level is enabled
logger.Debug("Expensive debug info: {Data}", ExpensiveOperation());
// ExpensiveOperation() only called if Debug level is enabled
```

### Exception Handling

Robust exception logging with context:

```csharp
try
{
    // Risky operation
}
catch (Exception ex)
{
    logger.Error(ex, "Operation failed for user {UserId} in context {Context}", 
        userId, operationContext);
    throw;
}
```

### Integration with Dependency Injection

```csharp
// Program.cs / Startup.cs
services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddSerilog(); // or any other provider
});

// In your services
public class OrderService
{
    private readonly ILogger<OrderService> _logger;

    public OrderService(ILogger<OrderService> logger)
    {
        _logger = logger;
    }

    public async Task ProcessOrderAsync(int orderId)
    {
        using (_logger.TimeOperation("OrderProcessing"))
        {
            _logger.Information("Starting order processing for {OrderId}", orderId);
            
            try
            {
                // Processing logic
                _logger.Information("Order {OrderId} processed successfully", orderId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to process order {OrderId}", orderId);
                throw;
            }
        }
    }
}
```

## Configuration

The library works with any `ILogger` implementation and follows standard .NET logging configuration:

```csharp
// appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "System": "Warning"
    }
  }
}
```

## Performance Considerations

- All methods include automatic level checks to avoid expensive operations
- Structured parameters use efficient formatting
- Scopes are implemented with minimal overhead
- Testing framework is optimized for fast test execution

## Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for details.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for a detailed history of changes.

---

Built with ❤️ by [LayeredCraft](https://github.com/LayeredCraft)
