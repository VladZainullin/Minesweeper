namespace Minesweeper.Core.Cells.Contents;

public sealed class SpaceContent : IHasValue
{
    public ConsoleColor ForegroundColor => default;

    public ConsoleColor BackGroundColor => default;
    
    public string Value => " ";
}