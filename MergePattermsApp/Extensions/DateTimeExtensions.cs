using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergePattermsApp.Extensions;
// Teaching pattern matching extensions
internal static class DateTimeExtensions
{
    /*
     * Statement body
     */
    public static bool IsWeekend(this DateTime sender)
        => (sender.DayOfWeek == DayOfWeek.Sunday || sender.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekDay(this DateTime sender)
        => !sender.IsWeekend();

    public static bool IsWeekDay(this DayOfWeek sender)
    {
        return sender == DayOfWeek.Monday || sender == DayOfWeek.Tuesday || sender == DayOfWeek.Wednesday ||
               sender == DayOfWeek.Thursday || sender == DayOfWeek.Friday;
    }

    public static bool IsWeekend(this DayOfWeek sender) => !sender.IsWeekDay();
}
