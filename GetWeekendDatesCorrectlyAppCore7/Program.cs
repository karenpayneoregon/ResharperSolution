namespace GetWeekendDatesCorrectlyAppCore7;

internal partial class Program
{
    static void Main(string[] args)
    {
        /*
         * Old style would use a using statement which means additional indentation, R# provides option as
         * done below to create a using directive
         *
         * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/using
         *
         */
        
        //using var context = new StoreContext();

        // Teaching using statement to using declaration
        using (var context = new StoreContext())
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            /*
             * Teaching rename o to order demo 
             */
            var saturdayOrSundayDelivered = context.Orders.AsEnumerable().Where(o => o.DeliveredDate.IsWeekend()).ToList();

            var weekEndTable = CreateOrderTable("Weekend");
            foreach (var order in saturdayOrSundayDelivered)
            {
                weekEndTable.AddRow(order.Id.ToString(), order.OrderDate.ToShortDateString(), order.DeliveredDate.ToString("yyyy-M-d dddd"));
            }

            AnsiConsole.Write(weekEndTable);
            Console.WriteLine();

            var weekDayTable = CreateOrderTable("Weekday");
            var weekdayDeliveries = context.Orders.AsEnumerable().Where(o => !o.DeliveredDate.IsWeekend()).ToList();
            foreach (var order in weekdayDeliveries)
            {
                weekDayTable.AddRow(order.Id.ToString(), order.OrderDate.ToShortDateString(), order.DeliveredDate.ToString("yyyy-M-d dddd"));
            }
            AnsiConsole.Write(weekDayTable);

            Console.WriteLine();

            var groupWeek = context.Orders
                .AsEnumerable()
                .GroupBy(x => x.DeliveredDate.DayOfWeek)
                .Where(x => x.Key.IsWeekDay())
                .ToList();

            var groupWeekend1 = context.Orders
                .AsEnumerable()
                .GroupBy(x => x.DeliveredDate.DayOfWeek)
                .Where(x => x.Key.IsWeekend())
                .ToList();


            var groupWeekend2 = context.Orders
                .AsEnumerable()
                .GroupBy(o => o.DeliveredDate.DayOfWeek)
                .Select(o => new ItemContainer(o.Key, o.ToList()))
                .OrderBy(x => x.DayOfWeek)
                .ToList();

            var groupedTable = CreateGroupTable();
            foreach (var grouped in groupWeekend2)
            {
                groupedTable.AddRow(grouped.DayOfWeek.ToString());
                foreach (var order in grouped.List)
                {
                    groupedTable.AddRow(order.Id.ToString(), order.DeliveredDate.ToShortDateString());
                }
            }

            AnsiConsole.Write(groupedTable);
        }


        Console.ReadLine();
    }
}