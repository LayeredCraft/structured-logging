using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Tests.TestKit.Specimens;

public class LogLevelSpecimen : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is Type type && type == typeof(LogLevel))
        {
            var logLevels = new[]
            {
                LogLevel.Trace,
                LogLevel.Debug,
                LogLevel.Information,
                LogLevel.Warning,
                LogLevel.Error,
                LogLevel.Critical
            };
            var random = new Random();
            return logLevels[random.Next(logLevels.Length)];
        }

        return new NoSpecimen();
    }
}