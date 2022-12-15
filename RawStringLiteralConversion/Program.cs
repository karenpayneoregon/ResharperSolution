namespace RawStringLiteralConversion;

internal partial class Program
{
    // Teaching to raw string literal
    static void Main(string[] args)
    {


        var json = @"[
  {
    ""Name"": ""Product 1"",
    ""ExpiryDate"": ""2000-12-29T00:00:00Z"",
    ""Price"": 99.95,
    ""Sizes"": null
  },
  {
    ""Name"": ""Product 2"",
    ""ExpiryDate"": ""2009-07-31T00:00:00Z"",
    ""Price"": 12.50,
    ""Sizes"": null
  }
]";

        Console.WriteLine(json);
        Console.ReadLine();

    }
}