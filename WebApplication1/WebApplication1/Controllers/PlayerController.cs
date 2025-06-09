using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    // GET /api/players/{id}/matches
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        var result = await _playerService.GetPlayerWithMatchesAsync(id);

        if (result == null)
            return NotFound($"Player with ID {id} not found.");

        return Ok(result);
    }

    // POST /api/players
    [HttpPost]
    public async Task<IActionResult> AddPlayer([FromBody] CreatePlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var error = await _playerService.AddPlayerWithMatchesAsync(dto);

        if (error != null)
            return BadRequest(error);

        return Created("", null);
    }
}