using SqlLiteLibrary.Data;
using SqlLiteLibrary.Models;

namespace SqlLiteLibrary.Classes;
public class DataOperations
{
    public delegate void OnIterate(FileContainer container);
    public static event OnIterate Iterate;
    /// <summary>
    /// Create a new database, file name is OnConfiguring in the DbContext <see cref="Context"/>
    /// </summary>
    public static void BuildData(Context context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.FileContainers.Add(new FileContainer() { Path1 = "A1", Path2 = "A2", Path3 = "A3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "B1", Path2 = "B2", Path3 = "B3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "C1", Path2 = "C2", Path3 = "C3" });

        context.SaveChanges();
    }
    /// <summary>
    /// Update a record by key
    /// </summary>
    public static void UpdateOneRecord1(Context context)
    {
        var item = context.FileContainers.FirstOrDefault(x => x.Id == 2);
        Console.WriteLine();
        item!.Path1 = "New path";
        context.SaveChanges();
    }
    /// <summary>
    /// Update a record by Path3
    /// </summary>
    public static void UpdateOneRecord2(Context context)
    {
        var item = context.FileContainers.FirstOrDefault(x => x.Path3 == "C3");
        Console.WriteLine();
        item!.Path3 = "New path";
        context.SaveChanges();
    }
    /// <summary>
    /// Display records generated above
    /// </summary>
    /// <param name="context"></param>
    public static void ShowData(Context context)
    {
        List<FileContainer> items = context.FileContainers.ToList();

        // Teaching foreach to for and back
        foreach (FileContainer container in items)
        {
            Iterate?.Invoke(container);
        }
    }

    public static void ReturnData1(Context context)
    {
        var items = context.FileContainers
            .Select(x => new {Id = x.Id, Path1 = x.Path1}).ToList();
    }


    public static List<FileContainerSmall> ReturnData2(Context context) 
        => context.FileContainers
            .Select(x => new FileContainerSmall(x.Id, x.Path1)).ToList();

    /// <summary>
    /// Poorly written
    /// - Allow ReSharper to fix Where/FirstOrDefault
    /// - Create expression body member
    /// </summary>
    public static FileContainer OneContainer(Context context, int id)
    {
        // Teaching Where should be FirstOrDefault
        return context.FileContainers.Where(x => x.Id == id).FirstOrDefault();
    }
}