using SqlServerLibrary;
using Switches.Classes;
using System.Globalization;
using static System.DateTime;
#pragma warning disable CA2208
namespace Switches;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);
        Console.WriteLine();
        SimpleExample();
        await DatabaseExample();

        Console.ReadLine();
    }



    private static async Task DatabaseExample()
    {
        if (DataHelpers.ExpressDatabaseExists("School"))
        {
            SchoolOperations.OnIteratePersonGradesEvent += SchoolOperationsOnOnIteratePersonGradesEvent;
            await Task.Run(async () => await SchoolOperations.GetGradesForPeople());
        }
        else
        {
            Console.WriteLine("Missing database");
        }
    }

    private static void SchoolOperationsOnOnIteratePersonGradesEvent(PersonGrades personGrades)
    {
        // Teaching invert if
        if (personGrades.Grade is not null)
        {
            Console.WriteLine($"{personGrades.PersonID,-3}{personGrades.FullName,20}" + 
                              $"{personGrades.Grade.Value.ToString(CultureInfo.CurrentCulture),8}" +
                              $"{personGrades.GradeLetter.PadRight(3),10}");
        };
    }

    private static void SimpleExample()
    {
        // Teaching - spelling
        AnsiConsole.MarkupLine(
            $"[mediumspringgreen]{nameof(Howdy)}.{nameof(Howdy.Greetings)}[/] [cyan]{Howdy.Greetings()}[/]");
        AnsiConsole.MarkupLine(
            $"[mediumspringgreen]{nameof(Howdy)}.{nameof(Howdy.TimeOfDay)}[/] [cyan]{Howdy.TimeOfDay()}[/]");
    }

    public static class Howdy
    {
        
        // Teaching switch expression
        public static string Greetings()
        {
            var result = "";
            if (Now.Hour < 12)
            {
                result = "Good Morning";
            }
            else if (Now.Hour < 16)
            {
                result = "Good Afternoon";
            }
            else if (Now.Hour < 20)
            {
                result = "Good Evening";
            }
            else
            {
                result = "Good Night";
            }

            return result;
        }


        public static string TimeOfDay() =>
            Now.Hour switch
            {
                <= 12 => "Good Morning",
                <= 16 => "Good Afternoon",
                <= 20 => "Good Evening",
                _ => "Good Night"
            };


    }


}

/// <summary>
/// Before and after, from conventional switch to switch expression
/// * Let's convert GetLengthConventional
/// </summary>
public static class LanguageExtensions
{
    public static int GetLengthConventional(this int sender)
    {
        switch (sender)
        {
            case < 0:
                throw new ArgumentOutOfRangeException();
            case 0:
                return 1;
            default:
                return (int)Math.Floor(Math.Log10(sender)) + 1;
        }
    }

    public static int GetLength(this int sender) => sender switch
    {
        < 0 => throw new ArgumentOutOfRangeException(),
        0 => 1,
        _ => (int)Math.Floor(Math.Log10(sender)) + 1
    };


}