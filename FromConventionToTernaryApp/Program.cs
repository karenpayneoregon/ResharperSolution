namespace FromConventionToTernaryApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var categoryName = "DairyProducts";
        if (Enum.TryParse(categoryName, true, out Categories category))
        {
            AnsiConsole.MarkupLine($"[cyan]Found[/]: [white]{category}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red1]Could not find[/] [white]{categoryName}[/]");
        }

        Console.ReadLine();
    }
}