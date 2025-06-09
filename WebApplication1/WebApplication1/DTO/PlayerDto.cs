namespace WebApplication1.DTO;

public class PlayerDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<MatchInfoDto> Matches { get; set; } = new();
}