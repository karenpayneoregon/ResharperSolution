using NFluent;
using SqlServerLibrary;


// ReSharper disable once CheckNamespace - do not change
namespace FilteredIncludeUnitTestProject;

public partial class MainTest
{

    /// <summary>
    /// This is to ensure the database was created and has tables populated
    /// Once these test pass go ahead and remove them.
    /// </summary>
    [TestInitialize]
    public void Initialization()
    {
        Check.That(DataHelpers.LocalDbDatabaseExists("NorthWindAzure3")).IsTrue();
        Check.That(DataHelpers.TablesArePopulated(
            "Server=(localdb)\\mssqllocaldb;Database=NorthWindAzure3;Trusted_Connection=True;Encrypt=False"))
            .IsTrue();
    }

    /// <summary>
    /// Perform cleanup after test runs using assertion on current test name.
    /// </summary>
    [TestCleanup]
    public void TestCleanup()
    {

    }
    /// <summary>
    /// Perform any initialize for the class
    /// </summary>
    /// <param name="testContext"></param>
    [ClassInitialize()]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }
}

