using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Shape
{
    public abstract double Perimeter { get; }
    public abstract double Area { get; }
}

public class Round : Shape
{
    public double Radius { get; }

    public Round(double radius)
    {
        Radius = radius;
    }

    public override double Perimeter => 2 * Math.PI * Radius;

    public override double Area => Math.PI * Radius * Radius;
}

public class Square : Shape
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public override double Perimeter => 4 * Side;

    public override double Area => Side * Side;
}

public class Triangle : Shape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double Perimeter => SideA + SideB + SideC;

    public override double Area
    {
        get
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
    }
}

public class Program
{
    public static void Main()
    {
        var roundShapes = new List<Round>
        {
            new Round(5),
            new Round(10),
            new Round(15),
            new Round(20),
            new Round(25)
        };

        var squareShapes = new List<Square>
        {
            new Square(5),
            new Square(10),
            new Square(15),
            new Square(20),
            new Square(25)
        };

        var triangleShapes = new List<Triangle>
        {
            new Triangle(3, 4, 5),
            new Triangle(5, 10, 12),
            new Triangle(7, 8, 9),
            new Triangle(9, 10, 11),
            new Triangle(11, 12, 13)
        };

        PrintSortedShapes(roundShapes);

        Console.WriteLine();

        PrintSortedShapes(squareShapes);

        Console.WriteLine();

        PrintSortedShapes(triangleShapes);

        Console.WriteLine();

        var combinedShapes = roundShapes.Concat(squareShapes).Concat(triangleShapes);

        PrintSortedShapes(combinedShapes.OrderByDescending(s => s.Area));
    }

    private static void PrintSortedShapes<TShape>(IEnumerable<TShape> shapes)
        where TShape : Shape
    {
        Console.WriteLine($"{typeof(TShape).Name}s:");

        Console.WriteLine("ShapettttPerimetertArea");
        Console.WriteLine("--------------------------------------------");

        foreach (var shape in shapes.OrderByDescending(s => s.Area))
        {
            Console.WriteLine($"{shape.GetType().Name}tttt{shape.Perimeter}t{shape.Area}");
        }
    }
}
