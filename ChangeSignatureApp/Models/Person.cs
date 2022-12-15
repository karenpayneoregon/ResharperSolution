namespace ChangeSignatureApp.Models;
public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly HireDate { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public override string ToString() => $"{Id} {FullName}";
}
