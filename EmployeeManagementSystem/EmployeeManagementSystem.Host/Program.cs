using EmployeeManagementSystem.Application.Helpers;
using EmployeeManagementSystem.Domain.Entity;
using EmployeeManagementSystem.Infrastructure.Persistence;
using EmployeeManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Host;

public class Program
{
    public static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=../EmployeeManagement.db");
        var context = new ApplicationDbContext(optionsBuilder.Options);

        var _employeeRepository = new EmployeeRepository(context);
        var _teamRepository = new TeamRepository(context);

        try
        {
            //Exercise 2 A
            var employeesWithVacations = _employeeRepository.GetEmployeesWithVacationsInYearAndTeam(".NET", 2019);

            if (employeesWithVacations == null)
            {
                throw new Exception("Employees with vacations in 2019 NOT FOUND");
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Employees with vacations in 2019");
            Console.WriteLine("--------------------------------");
            foreach (var employee in employeesWithVacations)
            {
                Console.WriteLine(employee.Name);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            //Exercise 2 B
            var employeesWithUsedVacationDays = _employeeRepository.GetEmployeesWithVacationDaysUsedInYear(2019);

            if (employeesWithUsedVacationDays == null)
            {
                throw new Exception("Employees with used vacation days cound in 2019 NOT FOUND");
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Employees with used vacation days in 2019");
            Console.WriteLine("--------------------------------");
            foreach (var item in employeesWithUsedVacationDays)
            {
                Console.WriteLine($"{item.Employee.Name}: {item.UsedVacationDays} used vacation days in 2019");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            //Exercise 2 C
            var teamWithoutVacationDays = _teamRepository.GetTeamsWithoutVacationDaysInYear(2019);

            if (teamWithoutVacationDays == null)
            {
                throw new Exception("Teams without vacation days in 2019 NOT FOUND");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Teams without vacation days in 2019");
            Console.WriteLine("--------------------------------");
            foreach (var team in teamWithoutVacationDays)
            {
                Console.WriteLine($"{team.Name}");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            var employeeData = _employeeRepository.GetEmployeeByIdWithAllData(1);
            if (employeeData == null)
            {
                throw new Exception("User with provided ID NOT FOUND");
            }

            //Exercise 3
            var freeDays = VacationCalculator.CountFreeDaysForEmployee(employeeData, employeeData.Vacations.ToList(), employeeData.VacationPackage);
            Console.WriteLine($"Free days for {employeeData.Name}: {freeDays}");

            //Exercise 4
            var canRequestVacation = VacationRequestValidator.CanEmployeeRequestVacation(employeeData, employeeData.Vacations.ToList(), employeeData.VacationPackage);
            Console.WriteLine($"Can {employeeData.Name} request vacation: {canRequestVacation}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}