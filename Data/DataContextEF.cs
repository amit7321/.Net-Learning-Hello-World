using helloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace helloWorld.Data;

public class DataContextEF : DbContext
{
    public DbSet<Computer>? Computers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (!dbContextOptionsBuilder.IsConfigured)
        {
            dbContextOptionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=dotNetCourse;TrustServerCertificate=true;Trusted_Connection=True",
                dbContextOptionsBuilder => dbContextOptionsBuilder.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Computer");
        modelBuilder.Entity<Computer>().HasKey(computer => computer.Mobo);
    }
}