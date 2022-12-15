using System.Linq.Expressions;

namespace Switches.Classes;

public partial class Person
{

    // Teaching to expression body member
    public static Expression<Func<Models.Person, PersonEntity>> Projection
    {
        get
        {
            return (student) => new PersonEntity()
            {
                PersonID = student.PersonID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grades = student.StudentGrade
            };
        }
    }
}