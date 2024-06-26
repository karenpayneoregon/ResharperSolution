﻿namespace ChangeSignatureApp.Classes;
public class Mocked
{
    public static List<Person> PeopleList()
    {
        var employees = new List<Employee>()
        {
            new() {Id = 1, FirstName = "Joe", LastName = "Jones", HireDate = new DateOnly(2018,12,1), ReportsTo = 5},
            new() {Id = 2, FirstName = "Mary", LastName = "Smith", HireDate = new DateOnly(2018,9,1), ReportsTo = 5},
            new() {Id = 3, FirstName = "Nancy", LastName = "Ravioli", HireDate = new DateOnly(2017,4,12), ReportsTo = 6},
            new() {Id = 4, FirstName = "Andrew", LastName = "Fuller", HireDate = new DateOnly(2019,7,2), ReportsTo = 6},
            new() {Id = 7, FirstName = "Steven", LastName = "Buchanan", HireDate = new DateOnly(2015,5,16), ReportsTo = 5},
            new() {Id = 9, FirstName = "Karen", LastName = "Stone", HireDate = new DateOnly(2020,5,16), ReportsTo = 8}
        };

        var people = new List<Person>()
        {
            new Manager() {Id = 5, FirstName = "Anne", LastName = "Wordsworth", HireDate = new DateOnly(2015,7,2), YearsAsManager = 3,Employees = employees.Take(2).ToList()},
            new Manager() {Id = 6, FirstName = "Bob", LastName = "Gallagher", HireDate = new DateOnly(2014,7,2), YearsAsManager = 4,Employees = employees.Skip(2).Take(2).ToList()},
            new Manager() {Id = 8, FirstName = "Michael", LastName = "Suyama", HireDate = new DateOnly(2014,7,2), YearsAsManager = 1,Employees = employees.Skip(employees.Count -1).Take(1).ToList()}
        };

        people.AddRange(employees);

        return people;
    }
}