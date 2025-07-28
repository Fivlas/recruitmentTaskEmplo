using Exercise1.Entity;

namespace Exercise1.Services;
public class VacationService
{
    //Save structure in memory
    //Static to be same data across all instances
    private static List<EmployeesStructure> _structure = new List<EmployeesStructure>();

    public static List<EmployeesStructure> FillEmployeesStructure(List<Employee> employees)
    {
        var result = new List<EmployeesStructure>();

        foreach (var employee in employees)
        {
            int level = 1;
            var current = employee;
            while (current.SuperiorId.HasValue)
            {
                var superior = employees.FirstOrDefault(e => e.Id == current.SuperiorId);
                if (superior == null)
                {
                    throw new Exception($"Superior with ID {current.SuperiorId} not found");
                }

                result.Add(new EmployeesStructure
                {
                    EmployeeId = employee.Id,
                    SuperiorId = superior.Id,
                    Level = level
                });

                level++;
                current = superior;
            }
        }

        _structure = result;
        return result;
    }

    public static int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
    {
        var relation = _structure.FirstOrDefault(es => es.EmployeeId == employeeId && es.SuperiorId == superiorId);
        return relation?.Level;
    }
}
