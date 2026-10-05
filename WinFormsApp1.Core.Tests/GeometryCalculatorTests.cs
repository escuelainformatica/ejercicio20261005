using WinFormsApp1.Core;

namespace WinFormsApp1.Core.Tests;

public class GeometryCalculatorTests
{
    private readonly GeometryCalculator _calculator = new();

    [Fact]
    public void CalculateArea_WithNominalValues_ReturnsExpectedResult()
    {
        var dimensions = new Dimensions { Alto = 2m, Ancho = 3m, Largo = 4m };

        var area = _calculator.CalculateArea(dimensions);

        Assert.Equal(52m, area);
    }

    [Fact]
    public void CalculatePerimeter_WithNominalValues_ReturnsExpectedResult()
    {
        var dimensions = new Dimensions { Alto = 2m, Ancho = 3m, Largo = 4m };

        var perimeter = _calculator.CalculatePerimeter(dimensions);

        Assert.Equal(36m, perimeter);
    }

    [Fact]
    public void CalculateArea_WithValidDecimalValues_ReturnsExpectedResult()
    {
        var dimensions = new Dimensions { Alto = 1.5m, Ancho = 2.25m, Largo = 3.75m };

        var area = _calculator.CalculateArea(dimensions);

        Assert.Equal(34.8750m, area);
    }

    [Fact]
    public void CalculatePerimeter_WithMinimumPositiveValues_ReturnsPositiveResult()
    {
        var dimensions = new Dimensions { Alto = 0.01m, Ancho = 0.01m, Largo = 0.01m };

        var perimeter = _calculator.CalculatePerimeter(dimensions);

        Assert.True(perimeter > 0m);
        Assert.Equal(0.12m, perimeter);
    }

    [Fact]
    public void CalculateArea_WhenAltoIsZero_ThrowsArgumentOutOfRangeException()
    {
        var dimensions = new Dimensions { Alto = 0m, Ancho = 2m, Largo = 3m };

        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateArea(dimensions));
    }

    [Fact]
    public void CalculatePerimeter_WhenAnchoIsNegative_ThrowsArgumentOutOfRangeException()
    {
        var dimensions = new Dimensions { Alto = 1m, Ancho = -2m, Largo = 3m };

        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculatePerimeter(dimensions));
    }

    [Fact]
    public void CalculateArea_WhenMultipleInvalidValues_ThrowsArgumentOutOfRangeException()
    {
        var dimensions = new Dimensions { Alto = 0m, Ancho = -2m, Largo = 3m };

        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateArea(dimensions));
    }

    [Fact]
    public void CalculateArea_WithLargeValues_ReturnsExpectedResult()
    {
        var dimensions = new Dimensions { Alto = 100000m, Ancho = 200000m, Largo = 300000m };

        var area = _calculator.CalculateArea(dimensions);

        Assert.Equal(220000000000m, area);
    }

    [Fact]
    public void CalculatePerimeter_WithLargeValues_ReturnsExpectedResult()
    {
        var dimensions = new Dimensions { Alto = 100000m, Ancho = 200000m, Largo = 300000m };

        var perimeter = _calculator.CalculatePerimeter(dimensions);

        Assert.Equal(2400000m, perimeter);
    }

    [Fact]
    public void CalculateArea_WhenDimensionsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _calculator.CalculateArea(null!));
    }
}
