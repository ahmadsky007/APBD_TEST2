using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerMatch>()
            .HasKey(pm => new { pm.PlayerId, pm.MatchId });

        modelBuilder.Entity<PlayerMatch>()
            .HasOne(pm => pm.Player)
            .WithMany(p => p.PlayerMatches)
            .HasForeignKey(pm => pm.PlayerId);

        modelBuilder.Entity<PlayerMatch>()
            .HasOne(pm => pm.Match)
            .WithMany(m => m.PlayerMatches)
            .HasForeignKey(pm => pm.MatchId);

        // Seed Example Data
        modelBuilder.Entity<Tournament>().HasData(
            new Tournament { TournamentId = 1, Name = "CS2 Summer Cup" }
        );

        modelBuilder.Entity<Match>().HasData(
            new Match { MatchId = 1, Date = DateTime.Parse("2025-07-02T15:00:00"), Map = "Inferno", Team1Score = 16, Team2Score = 12, TournamentId = 1 },
            new Match { MatchId = 2, Date = DateTime.Parse("2025-07-03T18:00:00"), Map = "Mirage", Team1Score = 10, Team2Score = 16, TournamentId = 1 }
        );

        modelBuilder.Entity<Player>().HasData(
            new Player { PlayerId = 1, FirstName = "Alex", LastName = "Smith", BirthDate = DateTime.Parse("2000-05-20") }
        );

        modelBuilder.Entity<PlayerMatch>().HasData(
            new PlayerMatch { PlayerId = 1, MatchId = 1, MVPs = 3, Rating = 1.25 },
            new PlayerMatch { PlayerId = 1, MatchId = 2, MVPs = 2, Rating = 1.10 }
        );
    }
}