using Mindbox.FigureCore.Exceptions;
using Mindbox.FigureCore.Interfaces;

namespace Mindbox.FigureCore;

/// <summary>
/// Треугольник
/// </summary>
public class Triangle : ITriangle
{
    private double _area;
    private bool _isRectangular;

    /// <summary>
    /// Сторона A
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Сторона B
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Сторона C
    /// </summary>
    public double SideC { get; }

    /// <summary>
    /// Признак является ли треугольник прямоугольным
    /// </summary>
    public bool IsRectangular { get { return _isRectangular; } }

    /// <summary>
    /// Конструктор треугольника
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        IsValid();
        CalculateArea();
        CheckForRectangular();
    }

    /// <summary>
    /// Получить площадь треугольника
    /// </summary>
    /// <returns>Площадь треугольника</returns>
    public double GetArea()
    {
        return _area;
    }

    private void CalculateArea()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2;
        _area = Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    private void CheckForRectangular()
    {
        var squareSideA = Math.Pow(SideA, 2);
        var squareSideB = Math.Pow(SideB, 2);
        var squareSideC = Math.Pow(SideC, 2);

        _isRectangular = (squareSideA == squareSideB + squareSideC) || (squareSideB == squareSideA + squareSideC) || (squareSideC == squareSideA + squareSideB);
    }

    private void IsValid()
    {
        if(SideA <= 0 || SideB <= 0 || SideC <= 0)
            throw new SideNotValidException("Стороны треугольника не могут быть меньше или равны нулю");

        if ((SideA >= SideB + SideC) || (SideB >= SideA + SideC) || (SideC >= SideA + SideB))
            throw new TriangleNotValidException("Невозможно построить треугольник по заданным сторонам");
    }
}
