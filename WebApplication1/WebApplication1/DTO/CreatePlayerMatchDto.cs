namespace WebApplication1.DTO;

using System.ComponentModel.DataAnnotations;

public class CreatePlayerMatchDto
{
    [Required]
    public int MatchId { get; set; }

    [Required]
    public int MVPs { get; set; }

    [Required]
    public double Rating { get; set; }
}