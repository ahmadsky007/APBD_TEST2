using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Player
{
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}