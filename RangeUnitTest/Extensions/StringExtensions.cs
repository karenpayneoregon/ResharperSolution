namespace RangeUnitTest.Extensions;

public static class StringExtensions
{
    public static string SubstringByIndexes(this string value, int startIndex, int endIndex) => 
        value[startIndex..(endIndex + 1)];

    public static bool EqualsIgnoreCase(this string first, string second) => 
        string.Equals(first, second, StringComparison.OrdinalIgnoreCase);

}