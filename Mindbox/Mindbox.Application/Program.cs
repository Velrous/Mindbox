using Mindbox.FigureCore;

internal class Program
{
    public static void Main(string[] args)
    {
        var circle = new Circle(3.6);
        var triangle = new Triangle(3,4,5);

        Console.WriteLine($"Радиус круга: {circle.Radius} Площадь круга: {circle.GetArea()}");
        Console.WriteLine($"Стороны треугольника: {triangle.SideA}, {triangle.SideB}, {triangle.SideC} Площадь треугольника: {triangle.GetArea()} " +
            $"Является ли треугольник прямоугольным? {triangle.IsRectangular}");
    }
}