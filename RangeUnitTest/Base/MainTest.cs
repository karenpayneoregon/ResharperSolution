using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using RangeUnitTest.Classes;
using static System.DateTime;


// ReSharper disable once CheckNamespace - do not change
namespace RangeUnitTest;

public partial class MainTest
{
    [TestInitialize]
    public void Init()
    {
        // better than a static string
        if (TestContext.TestName == nameof(BetweenDates))
        {
                
        }
    }
    [TestCleanup]
    public void TestCleanup()
    {
        // see above
        if (TestContext.TestName == "BetweenDates")
        {

        }
        else
        {

        }

    }

    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }
    /// <summary>
    /// Here is where any clean operations are performed for this class
    /// </summary>
    /// <returns></returns>
    [ClassCleanup()]
    public static async Task ClassCleanup()
    {
        await Task.Delay(0);
    }

    public static List<string> MonthNames() => Enumerable
        .Range(1, 12)
        .Select((index) => DateTimeFormatInfo.CurrentInfo.GetMonthName(index))
        .ToList();

    public DateTime StartDate => new(Now.Year, Now.Month, 3, 3, 0, 0, 0);
        
    public DateTime EndDate => new(Now.Year, Now.Month, 6, 6, 0, 0, 0);
        
    public List<DateTime> DateRange => Enumerable.Range(1, 20).Select(value => 
        new DateTime(Now.Year, Now.Month, value, 1, 0, 0, 0)).ToList();
        
    public List<string> Periods => new()
    {
        "2010 Fya",
        "2011 FYA",
        "2012 FYA",
        "2013 FYA",
        "1Q 2014A",
        "2Q 2014A",
        "3Q 2014A",
        "4Q 2014A",
        "2014 FYA"
    };

    public string[] FiveCitiesFromIndex =
    {
        "Alpine", 
        "Alsea", 
        "Altamont", 
        "Amity", 
        "Annex"
    };
    public string[] FiveCitiesFromBeginning =
    {
        "Adair Village",
        "Adams",
        "Adrian",
        "Albany",
        "Aloha"
    };

    public string[] Words => new [] {
        // index from start    index from end
        "The",      // 0                   ^9
        "quick",    // 1                   ^8
        "brown",    // 2                   ^7
        "fox",      // 3                   ^6
        "jumped",   // 4                   ^5
        "over",     // 5                   ^4
        "the",      // 6                   ^3
        "lazy",     // 7                   ^2
        "dog"       // 8                   ^1
    };              // 9 (or words.Length) ^0

    public string[] ExpectedCities => new[] {
        "Aloha",
        "Alpine",
        "Alsea",
        "Altamont",
        "Amity",
        "Annex",
        "Antelope",
        "Arlington",
        "Ashland"
    };
    public string[] ExpectedPeriod => new[] {
        "2010 Fya",
        "2011 FYA",
        "2012 FYA",
        "2013 FYA",
        "1Q 2014A",
        "2Q 2014A",
        "3Q 2014A"
    };

    public List<DateTime> ExpectedDates => new()
    {
        new(Now.Year, Now.Month, 3,1,0,0,0),
        new(Now.Year, Now.Month, 4,1,0,0,0),
        new(Now.Year, Now.Month, 5,1,0,0,0),
        new(Now.Year, Now.Month, 6,1,0,0,0)
    };

    public List<Contacts> ExpectedContacts => new()
    {
        new() {ContactId = 7, FirstName = "Frédérique", LastName = "Citeaux"},
        new() {ContactId = 8, FirstName = "Martín", LastName = "Sommer"},
        new() {ContactId = 9, FirstName = "Laurence", LastName = "Lebihan"},
        new() {ContactId = 10, FirstName = "Victoria", LastName = "Ashworth"},
        new() {ContactId = 11, FirstName = "Patricio", LastName = "Simpson"},
        new() {ContactId = 12, FirstName = "Francisco", LastName = "Chang"},
        new() {ContactId = 13, FirstName = "Yang", LastName = "Wang"},
        new() {ContactId = 14, FirstName = "Elizabeth", LastName = "Brown"}
    };

}