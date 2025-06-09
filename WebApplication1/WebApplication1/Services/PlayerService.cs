using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerDto?> GetPlayerWithMatchesAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Tournament)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        if (player == null)
            return null;

        var result = new PlayerDto
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatches.Select(pm => new MatchInfoDto
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map,
                Date = pm.Match.Date,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score,
                Team2Score = pm.Match.Team2Score
            }).ToList()
        };

        return result;
    }

    public async Task<string?> AddPlayerWithMatchesAsync(CreatePlayerDto dto)
    {
        // Validate that all match IDs exist
        var matchIds = dto.Matches.Select(m => m.MatchId).ToList();
        var existingMatches = await _context.Matches
            .Where(m => matchIds.Contains(m.MatchId))
            .Select(m => m.MatchId)
            .ToListAsync();

        if (existingMatches.Count != matchIds.Count)
            return "One or more matches not found.";

        var player = new Player
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate,
        };

        foreach (var match in dto.Matches)
        {
            player.PlayerMatches.Add(new PlayerMatch
            {
                MatchId = match.MatchId,
                MVPs = match.MVPs,
                Rating = match.Rating
            });
        }

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return null;
    }
}