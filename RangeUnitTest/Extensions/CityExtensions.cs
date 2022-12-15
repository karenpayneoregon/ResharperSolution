using RangeUnitTest.Classes;

namespace RangeUnitTest.Extensions;

public static class CityExtensions
{
    /// <summary>
    /// Get Indices for between two city names. Since city names are static there is no assertion on if a city exists.
    /// So if either city does not exists an exception is thrown
    /// </summary>
    /// <param name="sender">List of <seealso cref="City"/></param>
    /// <param name="firstCity">First city name</param>
    /// <param name="lastCity">Last city name</param>
    /// <returns>Start city index, last city index with ^ (hat)</returns>
    /// <remarks>
    /// To keep code short null checks are excluded
    /// </remarks>
    public static (Index startIndex, Index endIndex) BetweenCities(this List<City> sender, string firstCity, string lastCity)
    {

        return
        (
            // check possible actions from the light bulb
            sender.FirstOrDefault(city => city.Name.EqualsIgnoreCase(firstCity)).StartIndex,
            sender.FirstOrDefault(city => city.Name.EqualsIgnoreCase(lastCity)).EndIndex
        );

    }

    /// <summary>
    /// Get city indexes for between two cities with case insensitive compares and null checks 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="firstCity"></param>
    /// <param name="lastCity"></param>
    /// <returns></returns>
    public static (Index startIndex, Index endIndex, bool failed) BetweenCitiesSafe(this List<City> sender, string firstCity, string lastCity)
    {

        if (sender.FirstOrDefault(name => name.Name == firstCity) is not null && sender.FirstOrDefault(x => x.Name == lastCity) is not null)
        {
            return
            (
                sender.FirstOrDefault(city => city.Name.EqualsIgnoreCase(firstCity)).StartIndex,
                sender.FirstOrDefault(city => city.Name.EqualsIgnoreCase(lastCity)).EndIndex,
                false
            );
        }
        else
        {
            return (new Index(), new Index(), true);
        }
    }
}