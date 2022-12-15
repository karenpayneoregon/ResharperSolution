

namespace ExtractInterfaceApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[white on blue]Extract to interface[/]");
        Console.ReadLine();
    }
}

// lets create an interface here
public class Person
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    Action<string> Action { get; set; }
}


// lets create an interface in a new file
class Circle
{
    // let R# import
    //public Point Center { get; set; }
    // uncomment for ambiguous reference
    //public Color Color { get; private set; }
    public int Radius { get; set; }
    public void Draw()
    {
        // draw...
    }
}
