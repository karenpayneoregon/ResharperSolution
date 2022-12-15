using FilteredInclude.Classes;
using FilteredInclude.Data;
using FilteredInclude.Models;
using FilteredIncludeUnitTestProject.Base;
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


        Check.That(completelyWrong.Count).Equals(3);

        // This is best done with Global Query Filters
        List<IEnumerable<Orders>> filteredOnIsDeletedCustomers = context.Customers
            .Where(customer => customer.Orders.Any(order => order.IsDeleted.Value))
            .Include(customer => customer.Orders.Where(order => order.IsDeleted.Value == true))
            .ThenInclude(order => order.OrderDetails)
            .ThenInclude(orderDetails => orderDetails.Product)
            .Select(customer => customer.Orders.Where(order => order.IsDeleted.Value))
            .ToList();

        Console.WriteLine($"The following is correctly done ✔: count {filteredOnIsDeletedCustomers.Count}");
        Check.That(filteredOnIsDeletedCustomers.Count).Equals(3);


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