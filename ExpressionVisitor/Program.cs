using System;

// Visitor interface
public interface IExprVisitor<T>
{
    T VisitConstant(Constant c);
    T VisitAdd(Add a);
    T VisitSubtract(Subtract s);
    T VisitMultiply(Multiply m);
    T VisitDivide(Divide d);
}

// Abstract element
public abstract class Expr
{
    public abstract T Accept<T>(IExprVisitor<T> visitor);
}

// Elements
public class Constant : Expr
{
    public double Value { get; }
    public Constant(double value) => Value = value;
    public override T Accept<T>(IExprVisitor<T> visitor) => visitor.VisitConstant(this);
}

public class Add : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Add(Expr left, Expr right) { Left = left; Right = right; }
    public override T Accept<T>(IExprVisitor<T> visitor) => visitor.VisitAdd(this);
}

public class Subtract : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Subtract(Expr left, Expr right) { Left = left; Right = right; }
    public override T Accept<T>(IExprVisitor<T> visitor) => visitor.VisitSubtract(this);
}

public class Multiply : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Multiply(Expr left, Expr right) { Left = left; Right = right; }
    public override T Accept<T>(IExprVisitor<T> visitor) => visitor.VisitMultiply(this);
}

public class Divide : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Divide(Expr left, Expr right) { Left = left; Right = right; }
    public override T Accept<T>(IExprVisitor<T> visitor) => visitor.VisitDivide(this);
}

// Concrete Visitor: Evaluator
public class Evaluator : IExprVisitor<double>
{
    public double VisitConstant(Constant c) => c.Value;
    public double VisitAdd(Add a) => a.Left.Accept(this) + a.Right.Accept(this);
    public double VisitSubtract(Subtract s) => s.Left.Accept(this) - s.Right.Accept(this);
    public double VisitMultiply(Multiply m) => m.Left.Accept(this) * m.Right.Accept(this);
    public double VisitDivide(Divide d) => d.Left.Accept(this) / d.Right.Accept(this);
}

class Program
{
    static void Main()
    {
        // Expression: (3 + 5) * (10 - 2)
        Expr expr = new Multiply(
            new Add(new Constant(3), new Constant(5)),
            new Subtract(new Constant(10), new Constant(2))
        );

        var evaluator = new Evaluator();
        Console.WriteLine($"Result: {expr.Accept(evaluator)}"); // 64
    }
}

