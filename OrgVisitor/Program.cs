using System;
using System.Collections.Generic;

// Visitor interface
public interface IOrgVisitor
{
    void VisitEmployee(Employee e, int indent);
    void VisitManager(Manager m, int indent);
    void VisitDirector(Director d, int indent);
}

// Abstract element
public abstract class OrgNode
{
    public abstract void Accept(IOrgVisitor visitor, int indent = 0);
}

// Elements
public class Employee : OrgNode
{
    public string Name { get; }
    public string Role { get; }
    public Employee(string name, string role) { Name = name; Role = role; }

    public override void Accept(IOrgVisitor visitor, int indent) => visitor.VisitEmployee(this, indent);
}

public class Manager : OrgNode
{
    public string Name { get; }
    public List<OrgNode> Reports { get; }
    public Manager(string name, List<OrgNode> reports) { Name = name; Reports = reports; }

    public override void Accept(IOrgVisitor visitor, int indent) => visitor.VisitManager(this, indent);
}

public class Director : OrgNode
{
    public string Name { get; }
    public List<OrgNode> Managers { get; }
    public Director(string name, List<OrgNode> managers) { Name = name; Managers = managers; }

    public override void Accept(IOrgVisitor visitor, int indent) => visitor.VisitDirector(this, indent);
}

// Concrete Visitor: Hierarchy Printer
public class HierarchyPrinter : IOrgVisitor
{
    public void VisitEmployee(Employee e, int indent)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}- {e.Name} ({e.Role})");
    }

    public void VisitManager(Manager m, int indent)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}+ Manager: {m.Name}");
        foreach (var report in m.Reports)
            report.Accept(this, indent + 1);
    }

    public void VisitDirector(Director d, int indent)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}# Director: {d.Name}");
        foreach (var mgr in d.Managers)
            mgr.Accept(this, indent + 1);
    }
}

class Program
{
    static void Main()
    {
        var org = new Director("Praveen Nair", new List<OrgNode>
        {
            new Manager("Anuraj", new List<OrgNode>
            {
                new Employee("Sanjay", "Engineer"),
                new Employee("Vaisakh", "Designer")
            }),
            new Manager("Abhishek", new List<OrgNode>
            {
                new Employee("John", "QA")
            })
        });

        var printer = new HierarchyPrinter();
        org.Accept(printer,1);
    }
}
