
using Microsoft.EntityFrameworkCore;
using TestDemo.Models;

namespace TestDemo.Data;

public class FootballDbContext : DbContext
{
    public FootballDbContext(DbContextOptions<FootballDbContext> dbfc) : base(dbfc)

    {
    }

    public DbSet<Club> Clubs { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=TestDataBase1;Username=postgres;Password=123");
        }
        //optionsBuilder.UseSnakeCaseNamingConvention();
    }
}