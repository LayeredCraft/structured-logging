using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit3;
using LayeredCraft.StructuredLogging.Test.TestKit.Customizations;
using LayeredCraft.StructuredLogging.Test.TestKit.Specimens;

namespace LayeredCraft.StructuredLogging.Test.TestKit.Attributes;

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