using Microsoft.EntityFrameworkCore;
using SqlLiteLibrary.Data;

namespace SqlLiteLibrary.Classes;
internal class ReSharperExample
{
    public static async Task FromAnonymousToStrongTyped()
    {
        await using var context = new Context();
        var items = await context.FileContainers
            .Select(fc => new { fc.Id, fc.Path1 })
            .ToListAsync();
    }
}
