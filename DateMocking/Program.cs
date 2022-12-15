using Telerik.JustMock;

namespace DateMocking;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Mock.Arrange(() => DateTime.Now).Returns(new DateTime(1900, 4, 12));
        Console.WriteLine(DateTime.Now);
        Console.ReadLine();
    }
}