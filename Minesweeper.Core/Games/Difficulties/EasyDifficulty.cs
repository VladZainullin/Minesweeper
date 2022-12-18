namespace Minesweeper.Core.Games.Difficulties;

public sealed class EasyDifficulty : IDifficulty
{
    public string Title => "Easy";
    public int CountOfBomb => 1;
    public int Weight => 5;
    public int Height => 5;
}