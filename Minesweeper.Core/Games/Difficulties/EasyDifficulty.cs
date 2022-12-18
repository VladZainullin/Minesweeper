namespace Minesweeper.Core.Games.Difficulties;

public sealed class EasyDifficulty : IDifficulty
{
    public string Title => "Easy";
    public int CountOfBomb => 15;
    public int Weight => 15;
    public int Height => 15;
}