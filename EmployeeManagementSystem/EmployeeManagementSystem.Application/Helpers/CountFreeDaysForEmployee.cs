using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Application.Helpers;

public static class VacationCalculator
{
    public static int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
    {
        var currentYear = DateTime.Now.Year;

        if (vacationPackage.Year != currentYear) return 0;

        var usedDays = vacations
            .Where(v => v.EmployeeId == employee.Id && v.DateSince.Year == currentYear)
            .Sum(v => CalculateVacationDays(v));

        return Math.Max(0, vacationPackage.GrantedDays - usedDays);
    }


    //For reference this is the source of that calculation https://www.biznes.gov.pl/en/portal/004076
    private static int CalculateVacationDays(Vacation vacation)
    {
        // For partial vacations (hourly), calculate days by dividing hours by 8 (standard workday)
        if (vacation.IsPartialVacation == 1)
            return (int)Math.Ceiling(vacation.NumberOfHours / 8.0);

        // For regular vacations, calculate the total number of days including both start and end dates
        // This follows Polish labor law where each day of leave corresponds to 8 working hours
        return (vacation.DateUntil - vacation.DateSince).Days + 1;
    }
}