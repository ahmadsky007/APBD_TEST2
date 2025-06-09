using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Match
{
    public int MatchId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [MaxLength(50)]
    public string Map { get; set; } = null!;

    [Required]
    public int Team1Score { get; set; }

    [Required]
    public int Team2Score { get; set; }

    public int TournamentId { get; set; }

    public Tournament Tournament { get; set; } = null!;

    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}