namespace Minesweeper.Core.Games.Difficulties;

public sealed class NormalDifficulty : IDifficulty
{
    public string Title => "Normal";
    public int CountOfBomb => 10;
    public int Weight => 10;
    public int Height => 10;
}