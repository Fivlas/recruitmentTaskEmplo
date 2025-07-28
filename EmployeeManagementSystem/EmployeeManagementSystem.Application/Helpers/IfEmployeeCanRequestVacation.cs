using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Application.Helpers;

public static class VacationRequestValidator
{
    public static bool CanEmployeeRequestVacation(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
    { 
        var freeDays = VacationCalculator.CountFreeDaysForEmployee(employee, vacations, vacationPackage);
        return freeDays > 0;
    }
}
