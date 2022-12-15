namespace ChangeSignatureApp.Models;
public class Manager : Person
{
    public int YearsAsManager { get; set; }
    public List<Employee> Employees { get; set; }
}

public class Employee : Person
{
    public int ReportsTo { get; set; }
}
