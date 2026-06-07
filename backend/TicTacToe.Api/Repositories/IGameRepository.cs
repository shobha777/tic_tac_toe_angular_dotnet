using TicTacToe.Api.Models;

namespace TicTacToe.Api.Repositories;

public interface IGameRepository
{
    Game Create(Game game);

    Game? Get(Guid id);

    void Update(Game game);

    Scoreboard GetScoreboard();

    void ResetScoreboard();
}