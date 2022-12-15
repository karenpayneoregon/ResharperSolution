namespace ToStringApp;

/// <summary>
/// Kill several birds here
///
/// 1. ToString format
/// 2. Local methods
/// 3. Deconstruct
/// 4. Move to own classes
/// </summary>
internal partial class Program
{
    static void Main(string[] args)
    {
        bool result = false;
        DateOnly dateOnly = new DateOnly(2022, 12, 12);

        Console.WriteLine($"The date is {dateOnly.ToString("D")}");

        var dates = Enumerable
            .Range(1, 14)
            .Select(x => new DateOnly(2022, 12, x))
            .ToList();



        foreach (var date in dates)
        {
            // merge via ||
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                result = true; 
                break;
            }
        }




        Console.ReadLine();
    }

}

internal static class Extensions
{


    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
        (day, month, year) = (date.Day, date.Month, date.Year);
}

