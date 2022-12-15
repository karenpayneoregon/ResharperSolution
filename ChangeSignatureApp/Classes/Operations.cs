namespace ChangeSignatureApp.Classes;
internal class Operations
{
    #region Signature change
    public static Person AddPerson(string firstName, string lastName, DateOnly hireDate)
    {
        return new Person() { Id = 1, FirstName = firstName, LastName = lastName, HireDate = hireDate };
    }
    #endregion
    
    #region Collection initializer, target new, expression bodies 
    public static List<Person> Persons()
    {
        List<Person> persons = new List<Person>();
        persons.Add(new Person()   { Id = 1, FirstName = "Karen", LastName = "Payne", HireDate = new DateOnly(2022, 2, 2) });
        persons.Add(new Employee() { Id = 2, FirstName = "firstName", LastName = "lastName", HireDate = new DateOnly(2022, 2, 2)});
        persons.Add(new Manager()  { Id = 3, FirstName = "firstName", LastName = "lastName", HireDate = new DateOnly(2022, 2, 2)});
        return persons;
    }
    public static List<Person> PersonsRefactored() => new()
        {
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", HireDate = new DateOnly(2022, 2, 2) },
            new() { Id = 2, FirstName = "firstName", LastName = "lastName", HireDate = new DateOnly(2022, 2, 2) }
        };
    #endregion

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
