using TicTacToe.Api.Models;

namespace TicTacToe.Api.Repositories;

public class InMemoryGameRepository : IGameRepository
{
    private readonly Dictionary<Guid, Game> _games = new();

    private readonly Scoreboard _scoreboard = new();

    public Game Create(Game game)
    {
        _games[game.Id] = game;
        return game;
    }

    public Game? Get(Guid id)
    {
        _games.TryGetValue(id, out var game);
        return game;
    }

    public void Update(Game game)
    {
        _games[game.Id] = game;
    }

    public Scoreboard GetScoreboard()
    {
        return _scoreboard;
    }

    public void ResetScoreboard()
    {
        _scoreboard.XWins = 0;
        _scoreboard.OWins = 0;
        _scoreboard.Draws = 0;
    }
}