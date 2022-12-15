namespace GetWeekendDatesCorrectlyAppCore7.Classes;

internal static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime sender) 
        => (sender.DayOfWeek == DayOfWeek.Sunday || sender.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekDay(this DateTime sender)
        => !sender.IsWeekend();

    public static bool IsWeekDay(this DayOfWeek sender)
    {
        return sender is DayOfWeek.Monday or DayOfWeek.Tuesday || sender == DayOfWeek.Wednesday ||
               sender == DayOfWeek.Thursday || sender == DayOfWeek.Friday;
    }

    public static bool IsWeekend(this DayOfWeek sender) => !sender.IsWeekDay();

    public static bool IsWeekend(this DateOnly sender)
        => (sender.DayOfWeek == DayOfWeek.Sunday || sender.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekDay(this DateOnly sender)
        => !sender.IsWeekend();
}