namespace LayeredCraft.StructuredLogging.Tests;

public class SimpleTest
{
    [Fact]
    public void Simple_Test_Passes()
    {
        // Arrange
        var expected = 42;

        // Act
        var actual = 42;

        // Assert
        Assert.Equal(expected, actual);
    }
}