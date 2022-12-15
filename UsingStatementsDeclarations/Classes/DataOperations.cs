using System.Data;
using Microsoft.Data.SqlClient;

namespace UsingStatementsDeclarations.Classes;
internal class DataOperations
{
    private static string _connectionString =
        "Data Source=.\\sqlexpress;Initial Catalog=NorthWind2020;Integrated Security=True;Encrypt=False";

    /*
     * R# will assist with cancellationToken and using declarations plus additional await(s)
     */
    public static async Task<DataTable> ReadProductsTask(CancellationToken ct)
    {

        return await Task.Run(async () =>
        {
            var productTable = new DataTable();

            // Teaching - await and using declaration
            using (var cn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand { Connection = cn, CommandText = SelectStatement() })
                {
                    try
                    {
                        await cn.OpenAsync(ct);
                    }
                    catch (TaskCanceledException tce)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                    // Teaching - cancellation token
                    productTable.Load(await cmd.ExecuteReaderAsync());

                }
            }



            return productTable;

        });

    }
    private static string SelectStatement()
    {
        return "SELECT P.ProductID, P.ProductName, P.SupplierID, S.CompanyName, P.CategoryID, " +
               "C.CategoryName, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, " +
               "P.ReorderLevel, P.Discontinued, P.DiscontinuedDate " +
               "FROM  Products AS P INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID " +
               "INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID";
    }
}
