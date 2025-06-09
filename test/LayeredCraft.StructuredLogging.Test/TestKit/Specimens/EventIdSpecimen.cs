using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.Extensions.Logging;

namespace LayeredCraft.StructuredLogging.Test.TestKit.Specimens;

public class EventIdSpecimen : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is Type type && type == typeof(EventId))
        {
            var random = new Random();
            return new EventId(random.Next(1, 1000), context.Create<string>());
        }

        return new NoSpecimen();
    }
}