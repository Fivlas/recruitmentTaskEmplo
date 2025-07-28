using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EmployeeManagementSystem.Infrastructure.Persistence;

namespace EmployeeManagementSystem.Domain;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=../EmployeeManagement.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}