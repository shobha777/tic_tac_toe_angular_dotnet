using TicTacToe.Api.Models;

namespace TicTacToe.Api.Services;

public interface IGameService
{
    Game CreateGame(GameMode mode);

    Game? GetGame(Guid id);
}