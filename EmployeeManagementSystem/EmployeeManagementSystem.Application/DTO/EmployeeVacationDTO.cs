using EmployeeManagementSystem.Domain.Entity;

namespace EmployeeManagementSystem.Application.DTO;

public class EmployeeVacationDTO
{
    public Employee? Employee { get; set; }
    public int UsedVacationDays { get; set; }
}