using EmployeeManagementSystem.Application.DTO;
using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Application.Interface;

public interface IEmployeeRepositoryWithDTO
{
    List<EmployeeVacationDTO?> GetEmployeesWithVacationDaysUsedInYear(int year);
}