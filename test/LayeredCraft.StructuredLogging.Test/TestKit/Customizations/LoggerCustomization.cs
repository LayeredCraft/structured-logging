using AutoFixture;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LayeredCraft.StructuredLogging.Test.TestKit.Customizations;

public class LoggerCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() =>
        {
            var logger = Substitute.For<ILogger>();
            logger.IsEnabled(Arg.Any<LogLevel>()).Returns(true);
            return logger;
        });
    }
}