using EmployeeManagementSystem.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Vacation> Vacations { get; set; }
    public DbSet<VacationPackage> VacationPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Employee>()
            .HasKey(e => e.Id);

        builder.Entity<Employee>()
            .HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId);

        builder.Entity<Employee>()
            .HasOne(e => e.VacationPackage)
            .WithMany()
            .HasForeignKey(e => e.VacationPackageId);

        builder.Entity<Team>()
            .HasKey(t => t.Id);

        builder.Entity<Vacation>()
            .HasKey(v => v.Id);

        builder.Entity<Vacation>()
            .HasOne(v => v.Employee)
            .WithMany(e => e.Vacations)
            .HasForeignKey(v => v.EmployeeId);

        builder.Entity<VacationPackage>()
            .HasKey(vp => vp.Id);
    }
}
