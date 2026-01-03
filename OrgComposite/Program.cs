using System;
using System.Collections.Generic;

// Component
public abstract class OrgNode
{
    public abstract void PrintHierarchy(int indent = 0);
}

// Leaf
public class Employee : OrgNode
{
    public string Name { get; }
    public string Role { get; }
    public Employee(string name, string role) { Name = name; Role = role; }

    public override void PrintHierarchy(int indent = 0)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}- {Name} ({Role})");
    }
}

// Composite: Manager
public class Manager : OrgNode
{
    public string Name { get; }
    public List<OrgNode> Reports { get; }
    public Manager(string name, List<OrgNode> reports) { Name = name; Reports = reports; }

    public override void PrintHierarchy(int indent = 0)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}+ Manager: {Name}");
        foreach (var report in Reports)
            report.PrintHierarchy(indent + 1);
    }
}

// Composite: Director
public class Director : OrgNode
{
    public string Name { get; }
    public List<OrgNode> Managers { get; }
    public Director(string name, List<OrgNode> managers) { Name = name; Managers = managers; }

    public override void PrintHierarchy(int indent = 0)
    {
        string pad = new string(' ', indent * 2);
        Console.WriteLine($"{pad}# Director: {Name}");
        foreach (var mgr in Managers)
            mgr.PrintHierarchy(indent + 1);
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

        org.PrintHierarchy();
    }
}
