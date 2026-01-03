using System;

// Component
public abstract class Expr
{
    public abstract double Evaluate();
}

// Leaf
public class Constant : Expr
{
    public double Value { get; }
    public Constant(double value) => Value = value;
    public override double Evaluate() => Value;
}

// Composites
public class Add : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Add(Expr left, Expr right) { Left = left; Right = right; }
    public override double Evaluate() => Left.Evaluate() + Right.Evaluate();
}

public class Subtract : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Subtract(Expr left, Expr right) { Left = left; Right = right; }
    public override double Evaluate() => Left.Evaluate() - Right.Evaluate();
}

public class Multiply : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Multiply(Expr left, Expr right) { Left = left; Right = right; }
    public override double Evaluate() => Left.Evaluate() * Right.Evaluate();
}

public class Divide : Expr
{
    public Expr Left { get; }
    public Expr Right { get; }
    public Divide(Expr left, Expr right) { Left = left; Right = right; }
    public override double Evaluate() => Left.Evaluate() / Right.Evaluate();
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

        Console.WriteLine($"Result: {expr.Evaluate()}"); // 64
    }
}

