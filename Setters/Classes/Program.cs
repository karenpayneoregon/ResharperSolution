using ConsoleHelperLibrary.Classes;
using System;
using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace Setters
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}





