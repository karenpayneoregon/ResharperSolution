using System.Runtime.CompilerServices;
using Spectre.Console;
using SqlLiteLibrary.Data;
using SqlLiteLibrary.Models;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MsBuildWorkingDirApp;

partial class Program
{
        
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";

        W.SetConsoleWindowPosition(W.AnchorWindow.Center);

        AnsiConsole.Write(
            new Panel(new Text("MS-Build working folder example").Centered())
                .Expand()
                .SquareBorder()
                .BorderStyle(new Style(Color.DarkViolet))
                .Header("[white on DarkViolet]About[/]")
                .HeaderAlignment(Justify.Center));
    }
}