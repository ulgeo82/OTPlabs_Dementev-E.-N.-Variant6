using Microsoft.EntityFrameworkCore;
using ProjectWorkTimeAccounting.Entities;

namespace ProjectWorkTimeAccounting;

// Контекст базы данных учета рабочего времени и зарплаты
public class DataContext : DbContext
{
    private const string ConnectionString =
        "Host=10.211.55.2;Port=5433;Database=work_time_accounting;Username=postgres;Password=Sda732810927109";

    public DbSet<Qualification> Qualifications { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<WorkTimeRecord> WorkTimeRecords { get; set; }

    public DbSet<WorkTimeRecordProject> WorkTimeRecordProjects { get; set; }

    public DbSet<SalaryPayment> SalaryPayments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(x => x.Qualification)
            .WithMany()
            .HasForeignKey(x => x.QualificationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(x => x.Developer)
            .WithMany()
            .HasForeignKey(x => x.DeveloperId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkTimeRecord>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SalaryPayment>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkTimeRecordProject>()
            .HasKey(x => new { x.WorkTimeRecordId, x.ProjectId });

        modelBuilder.Entity<WorkTimeRecordProject>()
            .HasOne(x => x.WorkTimeRecord)
            .WithMany(x => x.WorkTimeRecordProjects)
            .HasForeignKey(x => x.WorkTimeRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkTimeRecordProject>()
            .HasOne(x => x.Project)
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
