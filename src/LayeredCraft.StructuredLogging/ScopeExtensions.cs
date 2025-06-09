using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace LayeredCraft.StructuredLogging;

/// <summary>
/// Provides extension methods for creating structured logging scopes with typed parameters and contextual information.
/// These scopes add structured data to all log entries within their lifetime, enabling better log correlation and filtering.
/// </summary>
public static class ScopeExtensions
{
    /// <summary>
    /// Creates a logging scope with a single named typed property that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name">The name of the property to add to the scope.</param>
    /// <param name="value">The value of the property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginScope("UserId", userId))
    /// {
    ///     logger.LogInformation("User operation completed"); // Will include UserId property
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginScope<T>(this ILogger logger, string name, T value)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name] = value
        });
    }

    /// <summary>
    /// Creates a logging scope with two named typed properties that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name0">The name of the first property to add to the scope.</param>
    /// <param name="value0">The value of the first property to add to the scope.</param>
    /// <param name="name1">The name of the second property to add to the scope.</param>
    /// <param name="value1">The value of the second property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginScope("UserId", userId, "RequestId", requestId))
    /// {
    ///     logger.LogInformation("Processing request"); // Will include both UserId and RequestId properties
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginScope<T0, T1>(this ILogger logger, string name0, T0 value0, string name1, T1 value1)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name0] = value0,
            [name1] = value1
        });
    }

    /// <summary>
    /// Creates a logging scope with three named typed properties that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name0">The name of the first property to add to the scope.</param>
    /// <param name="value0">The value of the first property to add to the scope.</param>
    /// <param name="name1">The name of the second property to add to the scope.</param>
    /// <param name="value1">The value of the second property to add to the scope.</param>
    /// <param name="name2">The name of the third property to add to the scope.</param>
    /// <param name="value2">The value of the third property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    public static IDisposable BeginScope<T0, T1, T2>(this ILogger logger, string name0, T0 value0, string name1, T1 value1, string name2, T2 value2)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name0] = value0,
            [name1] = value1,
            [name2] = value2
        });
    }

    /// <summary>
    /// Creates a logging scope with four named typed properties that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name0">The name of the first property to add to the scope.</param>
    /// <param name="value0">The value of the first property to add to the scope.</param>
    /// <param name="name1">The name of the second property to add to the scope.</param>
    /// <param name="value1">The value of the second property to add to the scope.</param>
    /// <param name="name2">The name of the third property to add to the scope.</param>
    /// <param name="value2">The value of the third property to add to the scope.</param>
    /// <param name="name3">The name of the fourth property to add to the scope.</param>
    /// <param name="value3">The value of the fourth property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    public static IDisposable BeginScope<T0, T1, T2, T3>(this ILogger logger, string name0, T0 value0, string name1, T1 value1, string name2, T2 value2, string name3, T3 value3)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name0] = value0,
            [name1] = value1,
            [name2] = value2,
            [name3] = value3
        });
    }

    /// <summary>
    /// Creates a logging scope with five named typed properties that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name0">The name of the first property to add to the scope.</param>
    /// <param name="value0">The value of the first property to add to the scope.</param>
    /// <param name="name1">The name of the second property to add to the scope.</param>
    /// <param name="value1">The value of the second property to add to the scope.</param>
    /// <param name="name2">The name of the third property to add to the scope.</param>
    /// <param name="value2">The value of the third property to add to the scope.</param>
    /// <param name="name3">The name of the fourth property to add to the scope.</param>
    /// <param name="value3">The value of the fourth property to add to the scope.</param>
    /// <param name="name4">The name of the fifth property to add to the scope.</param>
    /// <param name="value4">The value of the fifth property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    public static IDisposable BeginScope<T0, T1, T2, T3, T4>(this ILogger logger, string name0, T0 value0, string name1, T1 value1, string name2, T2 value2, string name3, T3 value3, string name4, T4 value4)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name0] = value0,
            [name1] = value1,
            [name2] = value2,
            [name3] = value3,
            [name4] = value4
        });
    }

    /// <summary>
    /// Creates a logging scope with six named typed properties that will be included in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T0">The type of the first property value.</typeparam>
    /// <typeparam name="T1">The type of the second property value.</typeparam>
    /// <typeparam name="T2">The type of the third property value.</typeparam>
    /// <typeparam name="T3">The type of the fourth property value.</typeparam>
    /// <typeparam name="T4">The type of the fifth property value.</typeparam>
    /// <typeparam name="T5">The type of the sixth property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name0">The name of the first property to add to the scope.</param>
    /// <param name="value0">The value of the first property to add to the scope.</param>
    /// <param name="name1">The name of the second property to add to the scope.</param>
    /// <param name="value1">The value of the second property to add to the scope.</param>
    /// <param name="name2">The name of the third property to add to the scope.</param>
    /// <param name="value2">The value of the third property to add to the scope.</param>
    /// <param name="name3">The name of the fourth property to add to the scope.</param>
    /// <param name="value3">The value of the fourth property to add to the scope.</param>
    /// <param name="name4">The name of the fifth property to add to the scope.</param>
    /// <param name="value4">The value of the fifth property to add to the scope.</param>
    /// <param name="name5">The name of the sixth property to add to the scope.</param>
    /// <param name="value5">The value of the sixth property to add to the scope.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    public static IDisposable BeginScope<T0, T1, T2, T3, T4, T5>(this ILogger logger, string name0, T0 value0, string name1, T1 value1, string name2, T2 value2, string name3, T3 value3, string name4, T4 value4, string name5, T5 value5)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name0] = value0,
            [name1] = value1,
            [name2] = value2,
            [name3] = value3,
            [name4] = value4,
            [name5] = value5
        });
    }

    /// <summary>
    /// Creates a logging scope that automatically includes caller information (method name, file path, and line number)
    /// in all log entries within the scope. This is useful for debugging and tracing.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginCallerScope())
    /// {
    ///     logger.LogInformation("Operation started"); // Will include MemberName, FileName, FilePath, and LineNumber
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginCallerScope(this ILogger logger,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            ["MemberName"] = memberName,
            ["FileName"] = Path.GetFileName(filePath),
            ["FilePath"] = filePath,
            ["LineNumber"] = lineNumber
        });
    }

    /// <summary>
    /// Creates a logging scope that includes both a custom typed property and automatic caller information
    /// (method name, file path, and line number) in all log entries within the scope.
    /// </summary>
    /// <typeparam name="T">The type of the custom property value.</typeparam>
    /// <param name="logger">The logger instance.</param>
    /// <param name="name">The name of the custom property to add to the scope.</param>
    /// <param name="value">The value of the custom property to add to the scope.</param>
    /// <param name="memberName">The name of the calling member. This is automatically populated by the compiler.</param>
    /// <param name="filePath">The path of the source file containing the caller. This is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file where this method is called. This is automatically populated by the compiler.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginCallerScope("UserId", userId))
    /// {
    ///     logger.LogInformation("User operation started"); // Will include UserId plus caller info
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginCallerScope<T>(this ILogger logger, string name, T value,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        return logger.BeginScope(new Dictionary<string, object?>
        {
            [name] = value,
            ["MemberName"] = memberName,
            ["FileName"] = Path.GetFileName(filePath),
            ["FilePath"] = filePath,
            ["LineNumber"] = lineNumber
        });
    }

    /// <summary>
    /// Creates a logging scope for web request correlation, adding RequestId and optionally UserId
    /// to all log entries within the scope. This is particularly useful for web applications.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="requestId">The unique identifier for the current request.</param>
    /// <param name="userId">The optional user identifier associated with the request.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginRequestScope(HttpContext.TraceIdentifier, user.Id))
    /// {
    ///     logger.LogInformation("Processing user request"); // Will include RequestId and UserId
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginRequestScope(this ILogger logger, string requestId, string? userId = null)
    {
        var scope = new Dictionary<string, object?>
        {
            ["RequestId"] = requestId
        };
        
        if (userId != null)
            scope["UserId"] = userId;
            
        return logger.BeginScope(scope);
    }

    /// <summary>
    /// Creates a logging scope for operation tracking, adding OperationName and OperationId
    /// to all log entries within the scope. If no operationId is provided, a new GUID is generated.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="operationName">The name of the operation being performed.</param>
    /// <param name="operationId">The optional unique identifier for the operation. If null, a new GUID is generated.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginOperationScope("ProcessPayment"))
    /// {
    ///     logger.LogInformation("Payment processing started"); // Will include OperationName and auto-generated OperationId
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginOperationScope(this ILogger logger, string operationName, string? operationId = null)
    {
        var scope = new Dictionary<string, object?>
        {
            ["OperationName"] = operationName
        };
        
        if (operationId != null)
            scope["OperationId"] = operationId;
        else
            scope["OperationId"] = Guid.NewGuid().ToString();
            
        return logger.BeginScope(scope);
    }

    /// <summary>
    /// Creates a logging scope for distributed tracing correlation, adding CorrelationId and optionally ParentId
    /// to all log entries within the scope. This is useful for tracking requests across multiple services.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="correlationId">The correlation identifier that tracks the request across services.</param>
    /// <param name="parentId">The optional parent identifier for hierarchical request tracking.</param>
    /// <returns>An IDisposable that should be disposed to end the scope.</returns>
    /// <example>
    /// <code>
    /// using (logger.BeginCorrelationScope(traceId, parentSpanId))
    /// {
    ///     logger.LogInformation("Service operation started"); // Will include CorrelationId and ParentId
    /// }
    /// </code>
    /// </example>
    public static IDisposable BeginCorrelationScope(this ILogger logger, string correlationId, string? parentId = null)
    {
        var scope = new Dictionary<string, object?>
        {
            ["CorrelationId"] = correlationId
        };
        
        if (parentId != null)
            scope["ParentId"] = parentId;
            
        return logger.BeginScope(scope);
    }
}