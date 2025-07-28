using Exercise1.Entity;
using Exercise1.Services;

namespace Exercise1;

internal class Program
{
    public static int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
    {
        return VacationService.GetSuperiorRowOfEmployee(employeeId, superiorId);
    }

    public static List<EmployeesStructure> FillEmployeesStructure(List<Employee> employees)
    {
        return VacationService.FillEmployeesStructure(employees);
    }

    public static void Main(string[] args)
    {
        var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Jan Kowalski", SuperiorId = null },
                new Employee { Id = 2, Name = "Kamil Nowak", SuperiorId = 1 },
                new Employee { Id = 3, Name = "Anna Mariacka", SuperiorId = 1 },
                new Employee { Id = 4, Name = "Andrzej Abacki", SuperiorId = 2 }
            };

        FillEmployeesStructure(employees);

        var row1 = GetSuperiorRowOfEmployee(2, 1); // row1 = 1
        Console.WriteLine($"Employee 2's level relative to Superior 1: {row1?.ToString() ?? "null"}");

        var row2 = GetSuperiorRowOfEmployee(4, 3); // row2 = null
        Console.WriteLine($"Employee 4's level relative to Superior 3: {row2?.ToString() ?? "null"}");

        var row3 = GetSuperiorRowOfEmployee(4, 1); // row3 = 2
        Console.WriteLine($"Employee 4's level relative to Superior 1: {row3?.ToString() ?? "null"}");
    }
}
