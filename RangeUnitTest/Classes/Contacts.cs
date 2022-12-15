using System.ComponentModel.DataAnnotations.Schema;
using RangeUnitTest.Interfaces;

namespace RangeUnitTest.Classes;

public class Contacts : IIndexer
{

    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public Index StartIndex { get; set; }
    [NotMapped]
    public Index EndIndex { get; set; }
    public override string ToString() => $"{ContactId, 3} {FirstName} {LastName}";
}