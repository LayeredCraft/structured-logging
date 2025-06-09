using AutoFixture;

namespace LayeredCraft.StructuredLogging.Tests.TestKit.Customizations;

public class ExceptionCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() => new Exception(fixture.Create<string>()));
        fixture.Register(() => new ArgumentException(fixture.Create<string>()));
        fixture.Register(() => new InvalidOperationException(fixture.Create<string>()));
    }
}