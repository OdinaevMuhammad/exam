namespace Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            
        modelBuilder.Entity<Employee>()
            .HasOne<Department>(s => s.Department)
            .WithMany(g => g.Employees)
            .HasForeignKey(s => s.DepartmentId);

             modelBuilder.Entity<Employee>()
            .HasOne<Job>(s => s.Job)
            .WithMany(g => g.Employees)
            .HasForeignKey(s => s.JobId);

            modelBuilder.Entity<Department>()
            .HasOne<Location>(s => s.Location)
            .WithMany(g => g.Departments)
            .HasForeignKey(s => s.Locationid);

                modelBuilder.Entity<Country>()
            .HasOne<Region>(s => s.Region)
            .WithMany(g => g.Countries)
            .HasForeignKey(s => s.Regionid);

                modelBuilder.Entity<JobHistory>()
            .HasOne<Job>(s => s.Job)
            .WithMany(g => g.JobHistories)
            .HasForeignKey(s => s.JobId);

                modelBuilder.Entity<Location>()
            .HasOne<Country>(s => s.Country)
            .WithMany(g => g.Locations)
            .HasForeignKey(s => s.CountryId);

                modelBuilder.Entity<JobHistory>()
            .HasOne<Employee>(s => s.Employee)
            .WithMany(g => g.JobHistories)
            .HasForeignKey(s => s.EmployeeId);

            
                modelBuilder.Entity<JobHistory>()
            .HasOne<Department>(s => s.Department)
            .WithMany(g => g.JobHistories)
            .HasForeignKey(s => s.DepartmentId);
    }
    
    public DbSet<Employee> Employees {get;set;}
    public DbSet<Department> Departments {get;set;}
    public DbSet<Country> Countries {get;set;}
    public DbSet<Job> Jobs {get;set;}
    public DbSet<JobHistory> JobHistories{get;set;}
    public DbSet<Region> Regions  {get;set;}
    public DbSet<Location> Locations {get;set;}
    public DbSet<JobGrade> JobGrades{get;set;}
}