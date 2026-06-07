namespace TicTacToe.Api.Models;

public class Game
{
    public Guid Id { get; set; }

    public string[][] Board { get; set; } =
[
    ["", "", ""],
    ["", "", ""],
    ["", "", ""]
];

    public string CurrentPlayer { get; set; } = "X";

    public GameMode Mode { get; set; }

    public GameStatus Status { get; set; } = GameStatus.InProgress;

    public string? Winner { get; set; }

    public List<CellPosition> WinningCells { get; set; } = new();

    public List<Move> MoveHistory { get; set; } = new();
}