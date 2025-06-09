using WebApplication1.DTO;

namespace WebApplication1.Services;

public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerWithMatchesAsync(int playerId);
    Task<string?> AddPlayerWithMatchesAsync(CreatePlayerDto dto);
}