using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FilteredIncludeUnitTestProject.Classes;
public static class Extensions
{
    public static List<TSource> ToLister<TSource>(this IEnumerable<TSource> source)
    {

        return new List<TSource>(source);
    }
}
