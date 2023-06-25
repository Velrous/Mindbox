using Mindbox.FigureCore.Exceptions;
using Mindbox.FigureCore.Interfaces;

namespace Mindbox.FigureCore;

/// <summary>
/// Круг
/// </summary>
public class Circle : ICircle
{
    private double _area;

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Конструктор круга
    /// </summary>
    /// <param name="radius">Радиус</param>
    public Circle(double radius)
    {
        Radius = radius;

        IsValid();
        CalculateArea();
    }

    /// <summary>
    /// Получить площадь круга
    /// </summary>
    /// <returns>Площадь круга</returns>
    public double GetArea()
    {
        return _area;
    }

    private void CalculateArea()
    {
        _area = Math.PI * Math.Pow(Radius, 2);
    }

    private void IsValid()
    {
        if (Radius <= 0)
            throw new RadiusNotValidException("Радиус не может быть меньше или равен нулю");
    }
}
