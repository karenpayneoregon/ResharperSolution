namespace RangeUnitTest.Classes;

public class FileOperations
{
    public static string[] OregonCities() => File.ReadAllLines("OregonCityNames.txt");
    public static string[] OregonCitiesFirstTen() => OregonCities().Take(10).ToArray();

}