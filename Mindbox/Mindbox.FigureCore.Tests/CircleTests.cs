using Mindbox.FigureCore.Exceptions;

namespace Mindbox.FigureCore.Tests;

public class CircleTests
{
    [Fact]
    public void GetArea_WithValidRadius_ExpectedCorrectArea()
    {
        var expected = 40.71504079052372;
        var circle = new Circle(3.6);

        Assert.Equal(expected, circle.GetArea());
    }

    [Fact]
    public void Radius_WithValidRadius_ExpectedInitialRadius()
    {
        var expected = 3;
        var circle = new Circle(expected);

        Assert.Equal(expected, circle.Radius);
    }

    [Fact]
    public void Constructor_WithNotValidRadius_ExpectedRadiusNotValidException()
    {
        Assert.Throws<RadiusNotValidException>(() => new Circle(0));
    }
}