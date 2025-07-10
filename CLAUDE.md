# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Common Development Commands

### Build and Test
```bash
dotnet build                                    # Build the solution
dotnet test                                     # Run all tests
dotnet test --logger "console;verbosity=detailed"  # Run tests with detailed output
dotnet pack                                     # Create NuGet packages
```

### Development Workflow
```bash
dotnet build LayeredCraft.StructuredLogging.sln  # Build entire solution
dotnet test test/LayeredCraft.StructuredLogging.Tests/  # Run specific test project
dotnet run --project test/LayeredCraft.StructuredLogging.Tests/  # Run test project directly
```

## Project Architecture

### Core Structure
- **src/LayeredCraft.StructuredLogging/** - Main library containing all logging extensions
- **test/LayeredCraft.StructuredLogging.Tests/** - Comprehensive test suite with xUnit3, AutoFixture, and NSubstitute

### Key Components
- **LoggerExtensionsBase.cs** - Internal base class providing optimized logging methods with level checks
- **Extension Classes** - Individual files for each log level (Debug, Information, Warning, Error, Critical, Verbose)
- **Specialized Extensions**:
  - **ScopeExtensions.cs** - Scope management and timed operations
  - **EnrichmentExtensions.cs** - Contextual logging with UserId, RequestId, CorrelationId
  - **PerformanceExtensions.cs** - Performance monitoring and timing utilities
  - **Testing/TestingExtensions.cs** - Testing framework with TestLogger and assertions

### Target Frameworks
- Multi-target: .NET 8.0, .NET 9.0, .NET Standard 2.1, .NET Standard 2.0
- Uses modern C# features with nullable reference types enabled

### Dependencies
- **Microsoft.Extensions.Logging.Abstractions** - Core logging abstraction
- **Test Dependencies**: xUnit3, AutoFixture, NSubstitute, AwesomeAssertions

## Development Guidelines

### Code Organization
- Each log level has its own extension class (e.g., `InformationExtensions.cs`)
- All extensions use the internal `LoggerExtensionsBase` for performance-optimized logging
- Performance checks (`logger.IsEnabled(logLevel)`) are built into base methods
- Comprehensive XML documentation is required for all public APIs

### Testing Strategy
- Test project uses xUnit3 with AutoFixture for test data generation
- NSubstitute for mocking ILogger instances
- AwesomeAssertions for fluent test assertions
- TestLogger framework provides specialized logging test utilities
- Tests are organized by feature area matching the main library structure

### Package Configuration
- NuGet package metadata is defined in the main project file
- Version is controlled via Directory.Build.props (currently 1.1.0)
- Package includes icon.png and README.md
- Source linking and symbol packages are enabled for debugging

### CI/CD Integration
- GitHub Actions workflow uses LayeredCraft shared templates
- Builds on .NET 8.0 and 9.0
- Automated package building and publishing on tags/releases