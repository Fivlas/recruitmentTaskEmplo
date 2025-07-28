using EmployeeManagementSystem.Application.Helpers;
using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Test;

public class UnitTest
{
    // Exercise 5
    [Fact]
    public void employee_can_request_vacation()
    {
        var employee = new Employee { Id = 1, Name = "John Doe" };
        var vacationPackage = new VacationPackage { Id = 1, Name = "Standard", GrantedDays = 25, Year = DateTime.Now.Year };
        var vacations = new List<Vacation>
        {
            new Vacation
            {
                Id = 1,
                EmployeeId = 1,
                DateSince = new DateTime(DateTime.Now.Year, 6, 1),
                DateUntil = new DateTime(DateTime.Now.Year, 6, 5),
                NumberOfHours = 40,
                IsPartialVacation = 0
            }
        };

        var remainingDays = VacationCalculator.CountFreeDaysForEmployee(employee, vacations, vacationPackage);

        Assert.Equal(20, remainingDays);
    }

    [Fact]
    public void employee_cant_request_vacation()
    {
        var employee = new Employee { Id = 1, Name = "John Doe" };
        var vacationPackage = new VacationPackage { Id = 1, Name = "Standard", GrantedDays = 25, Year = 2024 };
        var vacations = new List<Vacation>
        {
            new Vacation
            {
                Id = 1,
                EmployeeId = 1,
                DateSince = new DateTime(2024, 6, 1),
                DateUntil = new DateTime(2024, 6, 25),
                NumberOfHours = 200,
                IsPartialVacation = 0
            }
        };

        var remainingDays = VacationCalculator.CountFreeDaysForEmployee(employee, vacations, vacationPackage);

        Assert.Equal(0, remainingDays);
    }
}
