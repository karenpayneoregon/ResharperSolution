using System.Linq.Expressions;

namespace Switches.Classes;

public partial class StudentGrade
{

    // Teaching to expression body member
    public static Expression<Func<Models.StudentGrade, StudentEntity>> Projection
    {
        get
        {
            return (student) => new StudentEntity()
            {
                PersonID = student.StudentID,
                CourseID = student.CourseID,
                FirstName = student.Student.FirstName,
                LastName = student.Student.LastName,
                Grade = student.Grade
            };
        }
    }

}