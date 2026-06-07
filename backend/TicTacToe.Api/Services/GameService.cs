using TicTacToe.Api.Models;
using TicTacToe.Api.Repositories;

namespace TicTacToe.Api.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
    {
        _repository = repository;
    }

    public Game CreateGame(GameMode mode)
    {
        var game = new Game
        {
            Id = Guid.NewGuid(),
            Mode = mode,
            CurrentPlayer = "X",
            Status = GameStatus.InProgress
        };

        _repository.Create(game);

        return game;
    }

    public Game? GetGame(Guid id)
    {
        return _repository.Get(id);
    }
}