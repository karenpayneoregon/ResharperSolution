using FilteredInclude.Data;
using FilteredInclude.LanguageExtensions;
using FilteredInclude.Models;
using Newtonsoft.Json;

namespace FilteredInclude.Classes;

/// <summary>
/// Responsible for
/// 1. Creating our database
/// 2. Populating tables
/// </summary>

public class CreateOperations
{
    public static async Task<(bool success, Exception exception)> NewDatabase()
    {
        try
        {
            await using var context = new NorthWindContext(true,ConnectionOption.mssqllocaldb);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            return (true, null);

        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

    /// <summary>
    /// Each table must be populated individually as per a restriction on
    /// SET IDENTITY_INSERT
    /// </summary>
    public static void Populate()
    {
        CreateProducts();
        CreateCustomers();
        CreateOrders();
        CreateOrderDetails();
    }

    public static void CreateProducts()
    {
        var products = File.ReadAllText(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "products.json")).JSonToList<Products>();

        using var context = new NorthWindContext(true,ConnectionOption.mssqllocaldb);
        context.Products.AddRange(products);

        context.Database.OpenConnection();
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON");
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{nameof(CreateProducts)}: {exception.Message}");
        }
        finally
        {
            context.Database.CloseConnection();
        }
    }

    public static void CreateCustomers()
    {
        var customers = File.ReadAllText(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "Customers.json")).JSonToList<Customers>();

        using var context = new NorthWindContext(true,ConnectionOption.mssqllocaldb);
        context.Customers.AddRange(customers);

        context.Database.OpenConnection();
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers ON");
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers OFF");

        }
        catch (Exception exception)
        {
            Console.WriteLine($"{nameof(CreateCustomers)}: {exception.Message}");
        }
        finally
        {
            context.Database.CloseConnection();
        }
    }

    public static void CreateOrders()
    {
        List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(
            File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "Orders.json")));
            
        using var context = new NorthWindContext(true,ConnectionOption.mssqllocaldb);

        context.Orders.AddRange(orders);

        context.Database.OpenConnection();
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Orders ON");
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Orders OFF");

        }
        catch (Exception exception)
        {
            Console.WriteLine($"{nameof(CreateOrders)}: {exception.Message}");
        }
        finally
        {
            context.Database.CloseConnection();
        }
    }
    public static void CreateOrderDetails()
    {

        List<OrderDetails> orderDetails = JsonConvert.DeserializeObject<List<OrderDetails>>(
            File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "OrderDetails.json")));

        using var context = new NorthWindContext(true, ConnectionOption.mssqllocaldb);

        context.OrderDetails.AddRange(orderDetails);

        context.Database.OpenConnection();
        try
        {

            context.Database.ExecuteSqlRaw("ALTER TABLE [OrderDetails] NOCHECK CONSTRAINT ALL");
            Console.WriteLine($"Details {context.SaveChanges()}");

        }
        catch (Exception exception)
        {
            Console.WriteLine($"{nameof(CreateOrderDetails)}: {exception.Message}");
        }
        finally
        {
            context.Database.ExecuteSqlRaw("ALTER TABLE [OrderDetails] NOCHECK CONSTRAINT ALL");
            context.Database.CloseConnection();
        }
    }
}