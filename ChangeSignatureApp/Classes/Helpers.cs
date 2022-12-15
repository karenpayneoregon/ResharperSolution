namespace ChangeSignatureApp.Classes;
public class Helpers
{
    public static IEnumerable<List<Employee>> GetEmployeesWhereManagerHasThreeYearsAsManager(List<Person> people)
    {
        const int years = 3;

        foreach (var person in people)
        {
            /*
             * If Manager and has been for three years
             *
             * YearsAsManager equates to if YearsAsManager = 3
             * Employees: { } employees means to return list of employees under this manager
             *
             * 🔆 Cool stuff BUT only use if an entire team understands the syntax 🔆
             */
            if (person is Manager { YearsAsManager: years, Employees: { } employees })
            {
                yield return employees;
            }
        }
    }

}
