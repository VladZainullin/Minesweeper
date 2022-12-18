namespace Minesweeper.Core.Cells.Contents;

public sealed class BombContent : IHasValue
{
    public ConsoleColor ForegroundColor => default;

    public ConsoleColor BackGroundColor => default;
    public string Value => "@";
}