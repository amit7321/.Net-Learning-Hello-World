using helloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace helloWorld.Data;

public class DataContextEF : DbContext
{
    private string _connectionString;

    public DataContextEF(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public DbSet<Computer>? Computers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (!dbContextOptionsBuilder.IsConfigured)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString,
                dbContextOptionsBuilder => dbContextOptionsBuilder.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Computer");
        modelBuilder.Entity<Computer>().HasKey(computer => computer.Mobo);
    }
}