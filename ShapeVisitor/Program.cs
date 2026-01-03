using System;

// Visitor interface
public interface IShapeVisitor<T>
{
    T VisitCircle(Circle c);
    T VisitRectangle(Rectangle r);
    T VisitTriangle(Triangle t);
}

// Abstract element
public abstract class Shape
{
    public abstract T Accept<T>(IShapeVisitor<T> visitor);
}

// Elements
public class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;
    public override T Accept<T>(IShapeVisitor<T> visitor) => visitor.VisitCircle(this);
}

public class Rectangle : Shape
{
    public double Length { get; }
    public double Breadth { get; }
    public Rectangle(double l, double b) { Length = l; Breadth = b; }
    public override T Accept<T>(IShapeVisitor<T> visitor) => visitor.VisitRectangle(this);
}

public class Triangle : Shape
{
    public double Base { get; }
    public double Height { get; }
    public Triangle(double b, double h) { Base = b; Height = h; }
    public override T Accept<T>(IShapeVisitor<T> visitor) => visitor.VisitTriangle(this);
}

// Concrete Visitor: Area Calculator
public class AreaVisitor : IShapeVisitor<string>
{
    public string VisitCircle(Circle c) => $"Circle Area: {Math.PI * Math.Pow(c.Radius, 2)}";
    public string VisitRectangle(Rectangle r) => $"Rectangle Area: {r.Length * r.Breadth}";
    public string VisitTriangle(Triangle t) => $"Triangle Area: {0.5 * t.Base * t.Height}";
}

class Program
{
    static void Main()
    {
        Shape sc01 = new Circle(10.0);
        Shape sc02 = new Rectangle(10.0, 2.0);

        var areaVisitor = new AreaVisitor();

        Console.WriteLine(sc01.Accept(areaVisitor));
        Console.WriteLine(sc02.Accept(areaVisitor));
    }
}
