using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class PlayerMatch
{
    [Key, Column(Order = 0)]
    public int PlayerId { get; set; }

    [Key, Column(Order = 1)]
    public int MatchId { get; set; }

    public int MVPs { get; set; }

    public double Rating { get; set; }

    public Player Player { get; set; } = null!;

    public Match Match { get; set; } = null!;
}