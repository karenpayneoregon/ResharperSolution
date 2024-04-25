namespace FilteredIncludeUnitTestProject.Classes;
public static class Extensions
{
    public static List<TSource> ToLister<TSource>(this IEnumerable<TSource> source)
    {

        return new List<TSource>(source);
    }
}
