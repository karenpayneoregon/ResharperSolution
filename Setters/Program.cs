namespace Setters;

partial class Program
{
    /// <summary>
    /// Let's extract each sample into its own method
    /// </summary>
    static void Main(string[] args)
    {
        // Teaching C#11 INumber
        decimal someDecimal = 10.1234m;
        Console.WriteLine(someDecimal.Round(3));
        double someDouble = 10.1234;
        Console.WriteLine(someDouble.Round(3));

        Console.WriteLine(10.Clamp(1,8));
        Console.WriteLine(someDecimal.Clamp(1,8));
        Console.WriteLine(someDouble.Clamp(1,8));

        Console.ReadLine();
    }

}