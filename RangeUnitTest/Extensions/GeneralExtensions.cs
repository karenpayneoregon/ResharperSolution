using RangeUnitTest.Classes;

namespace RangeUnitTest.Extensions;

public static class GeneralExtensions
{
    /// <summary>
    /// Provides the ability to obtain a range for a list
    /// </summary>
    /// <typeparam name="T">List type</typeparam>
    /// <param name="list">Actual list</param>
    /// <param name="range"><see cref="Range"/></param>
    /// <returns></returns>
    /// <remarks>
    /// ranges are not supported for list which this method
    /// fills this gap
    /// </remarks>
    public static List<T> GetRange<T>(this List<T> list, Range range)
    {
        var (start, length) = range.GetOffsetAndLength(list.Count);
        return list.GetRange(start, length);
    }

    public static List<City> CityListIndices(this string[] citiesArray)
    {
        List<int> rangeReverse = Enumerable.Range(0, citiesArray.Length).Reverse().ToList();

        List<City> cities = citiesArray.Select(
            (cityName, index) => new City()
            {
                Name = cityName,
                StartIndex = new Index(index),
                EndIndex = new Index(rangeReverse[index], true)
            }).ToList();
        return cities;
    }

    /// <summary>
    /// Produces an array where the first element is startValue, last element is endValue with all values between both case insensitive.
    /// </summary>
    /// <param name="sender">List of <see cref="string"/></param>
    /// <param name="startValue">first element to start the range</param>
    /// <param name="endValue">last element to end the range</param>
    /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
    public static List<string> BetweenElements(this List<string> sender, string startValue, string endValue)
    {

        var startIndex = sender.FindIndex(element => 
            element.Equals(
                startValue, 
                StringComparison.OrdinalIgnoreCase));
            
        var endIndex = sender.FindIndex(element => 
            element.Equals(
                endValue, 
                StringComparison.OrdinalIgnoreCase)) - startIndex + 1;

        return startIndex == -1 || endIndex == -1 ? null : sender.GetRange(startIndex, endIndex);
            
    }
    /// <summary>
    /// Produces an array where the first element is startValue, last element is endValue with all values between both.
    /// </summary>
    /// <param name="sender">List of <see cref="int"/></param>
    /// <param name="startValue">first element to start the range</param>
    /// <param name="endValue">last element to end the range</param>
    /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
    public static List<int> BetweenElements(this List<int> sender, int startValue, int endValue)
    {

        var startIndex = sender.FindIndex(element => 
            element.Equals(startValue));
            
        var endIndex = sender.FindIndex(element => 
            element.Equals(endValue)) - startIndex + 1;

        return startIndex == -1 || endIndex == -1 ? 
            null : 
            sender.GetRange(startIndex, endIndex);
    }
        
        
    public static List<DateTime> BetweenDates(this List<DateTime> sender, DateTime startValue, DateTime endValue)
    {

        var startIndex = sender.FindIndex(element =>
            element.Date.Equals(startValue.Date));

        var endIndex = sender.FindIndex(element =>
            element.Date.Equals(endValue.Date)) - startIndex + 1;

        return startIndex == -1 || endIndex == -1 ?
            null :
            sender.GetRange(startIndex, endIndex);
    }
}