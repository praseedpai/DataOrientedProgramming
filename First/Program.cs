using System;
using System.Collections.Generic;
using System.Text.Json;

///////////////////////////////
//
// The First Demo Section
//
//
public record User(int Id, string Name, string Email);

public class UserService
{
    public string GetDisplayName(User user) =>
        $"{user.Name} ({user.Email})";

    public void PrintAllUsers(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(GetDisplayName(user));
        }
    }
}

//////////////////////////////////////////////////////
//
// Second Demo Section
//
//
//
// Using Dictionary instead of a custom class 

class DataStructurePrinter {
    // Generic function to print dictionary contents 
   public static void PrintData(IDictionary<string, object> data) { 
       foreach (var kvp in data) { 
           Console.WriteLine($"{kvp.Key}: {kvp.Value}"); 
       } 
   } 

}

///////////////////////////////////
//
// Third Demo Section
//
// Schema defined as a record
public record Order(int OrderId, string Customer, decimal Amount);

//////////////////////////////////
//
// Demo Code Snippets
//

class DemoAspects {

public static void DemoDataCodeSeperation() {

     var users = new List<User>
        {
            new User(1, "Alice", "alice@example.com"),
            new User(2, "Bob", "bob@example.com")
        };

        var service = new UserService();
        service.PrintAllUsers(users);

        // Immutable update using 'with'
        var updatedAlice = users[0] with { Email = "alice@newdomain.com" };
        Console.WriteLine($"Updated: {service.GetDisplayName(updatedAlice)}");

        // Schema vs Representation: serialize to JSON
        string json = JsonSerializer.Serialize(users);
        Console.WriteLine($"JSON Representation: {json}");


}

 public static void DemoGenericDataStructures() {

   

var product = new Dictionary<string, object> { 
    { "Id", 101 }, 
    { "Name", "Laptop" }, 
    { "Price", 1200.50 } 
}; 

DataStructurePrinter.PrintData(product);

}

public static void ThirdDemo() {

var order = new Order(5001, "Bob", 250.75m);

// Immutable: cannot change order fields after creation
string json = JsonSerializer.Serialize(order);
Console.WriteLine(json);

// Deserialize back into schema
var deserializedOrder = JsonSerializer.Deserialize<Order>(json);
Console.WriteLine(deserializedOrder);

}

}


///////////////////////////////////
//
//
//

// Generic method works for any numeric type 
class Calculator { 
    public static T Multiply<T>(T a, T b) where T : struct 
    { 
       dynamic x = a; 
       dynamic y = b; 
       return (T)(x * y); 
    } 
}

class Program
{
    static void Main()
    {
        DemoAspects.DemoGenericDataStructures() ;
        DemoAspects.DemoDataCodeSeperation();
        DemoAspects.ThirdDemo();
    }
}


