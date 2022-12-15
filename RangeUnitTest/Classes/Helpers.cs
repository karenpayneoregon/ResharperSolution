using System.Diagnostics.CodeAnalysis;

namespace RangeUnitTest.Classes;

public class Helpers
{
    /// <summary>
    /// Get elements between two elements 
    /// </summary>
    /// <param name="sender">string array</param>
    /// <param name="startItem">start element</param>
    /// <param name="endItem">end element</param>
    /// <returns>Range between start and end items or null</returns>
    public static string[] GetBetweenInclusive(string[] sender, [DisallowNull] string startItem, [DisallowNull] string endItem)
    {
        /*
         * Note this statement uses an anonymous type as there is no need to expose this outside of the current method
         */
        var elementsList = sender.Select((element, index) => new 
        {
            Name = element, 
            StartIndex = new Index(index), 
            EndIndex = new Index(Enumerable.Range(0, sender.Length).Reverse().ToList()[index], true)
        }).ToList();

        var start = elementsList.FirstOrDefault(item => item.Name == startItem);
        var end = elementsList.FirstOrDefault(item => item.Name == endItem);

        return start is null || end is null ? null : sender[start.StartIndex..end.EndIndex];
    }

    /// <summary>
    /// A method to learn how indices work against generic lists.
    /// Not intended to use in an application.
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="list">list to work with</param>
    /// <returns>list of <seealso cref="ElementContainer"/></returns>
    public static List<ElementContainer<T>> RangeDetails<T>(List<T> list)
    {
        var elementsList = list.Select((element, index) => new ElementContainer<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index], true)
        }).ToList();

        // Teaching show using .return
        return elementsList;
    }
}