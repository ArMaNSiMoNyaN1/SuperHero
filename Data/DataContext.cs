using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<SuperHero> SuperHeroes { get; set; }
    public DbSet<CartoonHero> CartoonHeroes { get; set; }
    public DbSet<Actor> Actors { get; set; }

    public DbSet<FootballPlayer> FootballPlayers { get; set; }

    public DbSet<Plane> Planes { get; set; }

    public DbSet<Phone> Phone { get; set; }

    public DbSet<Car> Car { get; set; }

    public DbSet<Excavator> Excavators { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuperHero>().HasKey(s => s.Id);
    }
}