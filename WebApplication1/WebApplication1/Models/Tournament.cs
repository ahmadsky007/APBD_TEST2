using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Tournament
{
    public int TournamentId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}