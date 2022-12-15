using ChangeSignatureApp.Classes;
using System.Net.Sockets;
using System.Text;

namespace ChangeSignatureApp;

/// <summary>
/// Besides change signature, let's look at extracting code to other locations
/// </summary>
internal partial class Program
{
    private static List<Person> _peopleList;
    private static StringBuilder _stringBuilder;
    static void Main(string[] args)
    {
        Person person1 = Operations.AddPerson("Karen", "Payne", new DateOnly(2022,10,1));

        _peopleList = Mocked.PeopleList();
        var people = _peopleList;
        _stringBuilder = new StringBuilder();

        _stringBuilder.AppendLine("Managers/Employees");
        _stringBuilder.AppendLine("");

        foreach (var person in people)
        {
            if (person is Manager manager)
            {
                _stringBuilder.AppendLine(manager.ToString());
                foreach (var employee in manager.Employees)
                {
                    _stringBuilder.AppendLine($"\t{employee, -30}");
                }
            }
        }

        Console.WriteLine(_stringBuilder);

        Console.WriteLine();

        _stringBuilder = new StringBuilder();

        _stringBuilder.AppendLine("Conditional YearsAsManager");
        _stringBuilder.AppendLine("");


        foreach (var person in people)
        {
            if (person is Manager manager)
            {

                var employees = manager.GetEmployeesWhereManagerHasYearsAsManager();

                if (employees == null) continue;

                foreach (var employee in employees)
                {
                    _stringBuilder.AppendLine($"{employee.Id,3} {employee.FullName}");
                }

            }
        }

        Console.WriteLine(_stringBuilder);

        Console.WriteLine();

        _stringBuilder = new StringBuilder();

        _stringBuilder.AppendLine("Recursive pattern with static condition");
        _stringBuilder.AppendLine("");


        foreach (var employeeList in Helpers.GetEmployeesWhereManagerHasThreeYearsAsManager(_peopleList))
        {
            var names = employeeList.Select(employee => employee.FullName).ToList().Select(fullName => fullName);

            foreach (var name in names)
            {
                _stringBuilder.AppendLine(name);
            }

        }

        Console.WriteLine(_stringBuilder);

        Console.ReadLine();
    }
}