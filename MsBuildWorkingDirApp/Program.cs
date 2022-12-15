using SqlLiteLibrary.Data;
using SqlLiteLibrary.Models;
using static SqlLiteLibrary.Classes.DataOperations;

namespace MsBuildWorkingDirApp;

internal partial class Program
{

    // Teaching Convert Anonymous to Named Type refactoring
    // Teaching Directory.Build.props
    static void Main(string[] args)
    {
        Helpers.PrintSampleName();
        Iterate += DataOperationsOnIterate;
        
        // Check actions
        // Teaching using statement to using declaration
        using (var context = new Context())
        {
            BuildData(context);
            ShowData(context);

            UpdateOneRecord1(context);
            UpdateOneRecord2(context);

            ShowData(context);

            /*
             * In DataOperations.ReturnData1 we query with a subset of properties which is anonymous thus can return data
             * while DataOperations.ReturnData2 started off as DataOperations.ReturnData1 and let ReSharper create a strong type class.
             * After creating the strong type it's moved to the Models folder with ReSharper assistance.
             */
            List<FileContainerSmall>? items = ReturnData2(context);
        }


        Console.ReadLine();
    }

    private static void DataOperationsOnIterate(FileContainer container)
    {
        Console.WriteLine($"{container.Id,-3}{container.Path1,-20}{container.Path2,-13}{container.Path3,-13}");
    }
}