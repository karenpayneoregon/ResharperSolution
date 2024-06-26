﻿using System.Text.Json;
using FilteredInclude.Models;

namespace FilteredInclude.LanguageExtensions
{
    public static class Extensions
    {

        // Teaching to statement body
        public static IQueryable<Orders> WhereDatesBetween(this IQueryable<Orders> sender, DateTime startDate, DateTime endDate)
            => sender.Where(order => startDate <= order.OrderDate  && order.OrderDate <= endDate);

        public static string ToYesNo(this bool value)
            => value ? "Yes" : "No";

        /// <summary>
        /// Convert a json string to a list of T
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="jsonString">Valid json</param>
        /// <returns>List&lt;T&gt;</returns>
        public static List<T> JSonToList<T>(this string jsonString)
            => JsonSerializer.Deserialize<List<T>>(jsonString, new JsonSerializerOptions());
    }
}
