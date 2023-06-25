using Mindbox.FigureCore.Exceptions;

namespace Mindbox.FigureCore.Tests;

public class TriangleTests
{
    [Fact]
    public void GetArea_WithValidSides_ExpectedCorrectArea()
    {
        var expected = 6;
        var triangle = new Triangle(3,4,5);

        Assert.Equal(expected, triangle.GetArea());
    }

    [Fact]
    public void Sides_WithValidSides_ExpectedInitialSides()
    {
        var sideA = 3;
        var sideB = 4;
        var sideC = 5;
        var triangle = new Triangle(sideA, sideB, sideC);

        Assert.Equal(sideA, triangle.SideA);
        Assert.Equal(sideB, triangle.SideB);
        Assert.Equal(sideC, triangle.SideC);
    }

    [Fact]
    public void IsRectangular_WithValidSides_ExpectedTrue()
    {
        var triangle = new Triangle(3, 4, 5);

        Assert.True(triangle.IsRectangular);
    }

    [Fact]
    public void IsRectangular_WithValidSides_ExpectedFalse()
    {
        var triangle = new Triangle(3, 3, 3);

        Assert.False(triangle.IsRectangular);
    }

    [Fact]
    public void Constructor_WithNotValidSides_ExpectedSideNotValidException()
    {
        Assert.Throws<SideNotValidException>(() => new Triangle(0, 0, 0));
    }

    [Fact]
    public void Constructor_WithNotValidSides_TriangleNotValidException()
    {
        Assert.Throws<TriangleNotValidException>(() => new Triangle(1, 2, 99));
    }
}