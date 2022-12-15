using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RangeUnitTest.Base;

public class TestBase
{
    protected TestContext TestContextInstance;
    public TestContext TestContext
    {
        get => TestContextInstance;
        set
        {
            TestContextInstance = value;
            TestResults.Add(TestContext);
        }
    }

    public static IList<TestContext> TestResults;
}