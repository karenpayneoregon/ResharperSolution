using System.Runtime.CompilerServices;

namespace HelperLibrary;

public class Helpers
{
    /// <summary>
    /// Display text to show name of current method
    /// </summary>
    /// <param name="methodName">no need to pass</param>
    public static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]Sample:[/] [white]{methodName}[/]");
        Console.WriteLine();
    }

    /// <summary>
    /// Display text to leave the app
    /// </summary>
    public static void ExitPrompt()
    {
        Console.WriteLine();
        
        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver"))
            .Centered());

        Console.ReadLine();
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }
}