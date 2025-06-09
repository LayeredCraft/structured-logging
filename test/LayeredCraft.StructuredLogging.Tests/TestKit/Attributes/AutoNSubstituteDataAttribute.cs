using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Tests.TestKit.Customizations;
using LayeredCraft.StructuredLogging.Tests.TestKit.Specimens;

namespace LayeredCraft.StructuredLogging.Tests.TestKit.Attributes;

public class AutoNSubstituteDataAttribute : AutoDataAttribute
{
    public AutoNSubstituteDataAttribute() : base(() => CreateFixture())
    {
    }

    private static IFixture CreateFixture()
    {
        var fixture = new Fixture();
        fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
        fixture.Customize(new LoggerCustomization());
        fixture.Customize(new ExceptionCustomization());
        fixture.Customizations.Add(new LogLevelSpecimen());
        fixture.Customizations.Add(new EventIdSpecimen());
        return fixture;
    }
}