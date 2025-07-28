using EmployeeManagementSystem.Domain.Interface;
using EmployeeManagementSystem.Domain.Entity;
using EmployeeManagementSystem.Infrastructure.Persistence;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Team?> GetTeamsWithoutVacationDaysInYear(int year)
    {
        var teamWithoutVacationDay = _context.Teams
            .Where(t => !_context.Employees
            .Where(e => e.TeamId == t.Id)
            .Any(e => e.Vacations.Any(v => v.DateSince.Year == year || v.DateUntil.Year == year)))
            .ToList();

        if (teamWithoutVacationDay.Count == 0)
        {
            return null;
        }

        return teamWithoutVacationDay;
    }
}