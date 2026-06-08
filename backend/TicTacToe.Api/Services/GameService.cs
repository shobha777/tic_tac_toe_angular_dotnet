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

    public Game? MakeMove(Guid gameId, int row, int column)
{
    var game = _repository.Get(gameId);

    if (game == null)
        return null;

    if (game.Board[row][column] != "")
        throw new InvalidOperationException("Cell already occupied");

    game.Board[row][column] = game.CurrentPlayer;

    game.MoveHistory.Add(new Move
    {
        MoveNumber = game.MoveHistory.Count + 1,
        Player = game.CurrentPlayer,
        Row = row,
        Column = column
    });

    game.CurrentPlayer =
        game.CurrentPlayer == "X"
            ? "O"
            : "X";

    _repository.Update(game);

    return game;
}
}