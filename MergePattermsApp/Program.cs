using HelperLibrary;

namespace MergePattermsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        BasicExample(args);
        ValidatingLinesExample();

        Helpers.ExitPrompt();
    }

    private static void BasicExample(string[] args)
    {
        Helpers.PrintSampleName();

        /*
         * R# see room for improvement - from this to the 2nd if statement. Note
         * that the variables are like declaring any variable thus unique names
         * Teaching merge patterns
         */
        if (args is ["-h", _] && args[1] is var topic)
        {
            AnsiConsole.MarkupLine($"[yellow]{topic}[/]");
        }


        if (args is ["-h", var topic1])
        {
            AnsiConsole.MarkupLine($"[yellow]{topic1}[/]");
        }

        /*
         * Place cursor on 'is' select `Replace with access expression`
         *
         * Karen's note, current assertion works fine but why for a simple
         * assertion? give it a rest and keep things simple.
         */
        if (args is {Length: 2})
        {
           AnsiConsole.MarkupLine("[yellow]Is two[/]"); 
        }
        else
        {
            AnsiConsole.MarkupLine("[yellow]Is not two[/]");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// List patterns
    /// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching#list-patterns
    /// </summary>
    private static void ValidatingLinesExample()
    {
        Helpers.PrintSampleName();

        string[] data = { "Mike,Jones,10,True", "Jane,Adams,A,True", "Karen,Smith,10,true", "Anne,Smith,50,false" };

        string[] lines = data
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        foreach (var line in lines)
        {
            var parts = line.Split(',');

            /*
             * R# suggest ternary operator, that is a personal choice
             * but if you need to debug avoid ternary or revert
             */
            if (parts is [ _ , _ , "10" or "50", "True" or "False" or "true" or "false"])
            {
                Console.WriteLine($"      Match {string.Join(",", parts)}");
            }
            else
            {
                Console.WriteLine($"Not a match {string.Join(",", parts)}");
            }
        }

        Console.WriteLine();

    }
}