namespace Minesweeper.Core.Games.Difficulties;

public sealed class HardDifficulty : IDifficulty
{
    public string Title => "Hard";
    public int CountOfBomb => 20;
    public int Weight => 20;
    public int Height => 20;
}