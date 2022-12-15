namespace ChangeSignatureApp.Classes;
public static class LanguageExtensions
{
    /// <summary>
    /// 🔆 Cool stuff BUT only use if an entire team understands the syntax 🔆
    /// </summary>
    public static List<Employee> GetEmployeesWhereManagerHasYearsAsManager(this Person person) => person switch
    {
        Manager { YearsAsManager: >= 4 } manager => manager.Employees,
        Manager { YearsAsManager: 3 } manager => manager.Employees,
        _ => null
    };
}

// Use ReSharper to move this class to a new file
public class Validates
{
    public static bool ValidateBirthYear(string birthYear) =>
        birthYear.Length == 4 && birthYear.All(char.IsDigit)
                              && int.TryParse(birthYear, out var year)
                              && year is >= 1920 and <= 2002;
}
