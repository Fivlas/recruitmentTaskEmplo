using System.Collections.Generic;
using EmployeeManagementSystem.Application.DTO;
using EmployeeManagementSystem.Application.Interface;
using EmployeeManagementSystem.Domain.Interface;
using EmployeeManagementSystem.Domain.Entity;
using EmployeeManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository, IEmployeeRepositoryWithDTO
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Employee?> GetEmployeesWithVacationsInYearAndTeam(string teamName, int year)
    {
        var employeesWithVacationInYearAndTeamName = _context.Employees
            .Include(e => e.Team)
            .Include(e => e.Vacations)
            .Where(e => e.Team.Name == teamName &&
                e.Vacations.Any(v => v.DateSince.Year == year || v.DateUntil.Year == year))
            .ToList();

        if (employeesWithVacationInYearAndTeamName.Count == 0)
        {
            return null;
        }

        return employeesWithVacationInYearAndTeamName;
    }

    public List<EmployeeVacationDTO?> GetEmployeesWithVacationDaysUsedInYear(int year)
    {
        var employeesWithVacationDaysUsedInYear = _context.Employees
            .Include(e => e.Vacations)
            .AsEnumerable()
            .Select(e => new EmployeeVacationDTO
            {
                Employee = e,
                UsedVacationDays = e.Vacations
                    .Where(v => v.DateSince.Year == year &&
                            v.DateUntil.Year == year &&
                            v.DateUntil < DateTime.Now &&
                            v.DateSince < DateTime.Now)
                    .Sum(v => (v.DateUntil - v.DateSince).Days + 1)
            })
            .ToList();

        if (employeesWithVacationDaysUsedInYear.Count == 0)
        {
            return null;
        }

        return employeesWithVacationDaysUsedInYear;
    }

    public Employee? GetEmployeeByIdWithAllData(int id)
    {
        var employeeData = _context.Employees
            .Include(e => e.Vacations)
            .Include(e => e.VacationPackage)
            .Include(e => e.Team)
            .FirstOrDefault(e => e.Id == id);

        if (employeeData == null)
        {
            return null;
        }

        return employeeData;
    }
}