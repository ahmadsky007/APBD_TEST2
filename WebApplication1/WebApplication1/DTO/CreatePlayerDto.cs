namespace WebApplication1.DTO;

using System.ComponentModel.DataAnnotations;

public class CreatePlayerDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public List<CreatePlayerMatchDto> Matches { get; set; } = new();
}