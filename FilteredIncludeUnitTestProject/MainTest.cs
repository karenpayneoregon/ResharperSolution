﻿using System.Xml;
using FilteredInclude.Classes;
using FilteredInclude.Data;
using FilteredInclude.Models;
using FilteredIncludeUnitTestProject.Base;
using FilteredIncludeUnitTestProject.Classes;
using Microsoft.EntityFrameworkCore;
using NFluent;

namespace FilteredIncludeUnitTestProject;

// Teaching create test method

// Teaching create test class

[TestClass]
public partial class MainTest : TestBase
{
     
    /// <summary>
    /// Example of doing filtered include semi right and then done proper.
    /// </summary>
    [TestMethod]
    [TestTraits(Trait.IncludeFilter)]
    public void GetOrdersFilterIncludeTest()
    {

        using var context = new NorthWindContext(false,ConnectionOption.mssqllocaldb);
        
        /*
         * Returns three customers 👍
         * Returns incorrect order count 👎
         * And incorrect orders
         */
        List<Customers> completelyWrong = context.Customers
            .Where(customer => customer.Orders.Any(order => order.IsDeleted.Value))
            .Include(customer => customer.Orders)
            .ThenInclude(order => order.OrderDetails)
            .ThenInclude(orderDetails => orderDetails.Product)
            .ToList();

        File.WriteAllText("Result1.txt", ObjectDumper.Dump(completelyWrong));

        Check.That(completelyWrong.Count).Equals(3);


        Console.WriteLine(string.Join(" ", completelyWrong.Select(x => x.Orders.Count)));

        // This is best done with Global Query Filters
        List<IEnumerable<Orders>> filteredRight = context.Customers
            .Where(customer => customer.Orders.Any(order => order.IsDeleted.Value))
            .Include(customer => customer.Orders.Where(order => order.IsDeleted.Value == true))
            .ThenInclude(order => order.OrderDetails)
            .ThenInclude(orderDetails => orderDetails.Product)
            .Select(customer => customer.Orders.Where(order => order.IsDeleted.Value))
            .ToList();

        File.WriteAllText("Result2.txt", ObjectDumper.Dump(filteredRight));
        Console.WriteLine($"The following is correctly done ✔: count {filteredRight.Count}");
        Check.That(filteredRight.Count).Equals(3);

        Console.WriteLine();

        List<IGrouping<int?, Orders>> flattenedList = filteredRight
            .SelectMany(eo => eo)
            .GroupBy(o => o.CustomerIdentifier)
            .ToList();

        Console.WriteLine();
        Check.That(flattenedList.Count).Equals(3);

        foreach (var item in flattenedList)
        {
            var current = item.FirstOrDefault();
            if (current is not null)
            {
                Console.WriteLine($"{item.Key,-8}{current.OrderDate,-15:d}{current.CustomerIdentifier, -4}{current.OrderDetails.Count}");
            }
        }

    }

    [TestMethod]
    [TestTraits(Trait.DatabaseSetup)]
    [Ignore]
    public async Task Setup()
    {
            
        var (success, exception) = await CreateOperations.NewDatabase();
            
        if (success)
        {
            CreateOperations.Populate();
        }
        else
        {
            Console.WriteLine(exception.Message);
        }
            
    }

}