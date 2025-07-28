using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Domain.Interface;
public interface IEmployeeRepository
{
    List<Employee?> GetEmployeesWithVacationsInYearAndTeam(string teamName, int year);
    Employee? GetEmployeeByIdWithAllData(int id);
}