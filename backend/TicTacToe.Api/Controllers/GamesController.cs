using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.DTOs;
using TicTacToe.Api.Services;

namespace TicTacToe.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public IActionResult CreateGame(
        [FromBody] CreateGameRequest request)
    {
        var game = _gameService.CreateGame(request.Mode);

        return Ok(game);
    }

    [HttpGet("{id}")]
    public IActionResult GetGame(Guid id)
    {
        var game = _gameService.GetGame(id);

        if (game == null)
            return NotFound();

        return Ok(game);
    }
    [HttpPost("{id}/moves")]
public IActionResult MakeMove(
    Guid id,
    [FromBody] MoveRequest request)
{
    try
    {
        var game = _gameService.MakeMove(
            id,
            request.Row,
            request.Column);

        if (game == null)
            return NotFound();

        return Ok(game);
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(ex.Message);
    }
}
}