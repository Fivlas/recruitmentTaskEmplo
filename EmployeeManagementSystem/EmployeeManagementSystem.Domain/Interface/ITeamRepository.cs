using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Domain.Interface;

public interface ITeamRepository
{ 
    List<Team?> GetTeamsWithoutVacationDaysInYear(int year);
}
