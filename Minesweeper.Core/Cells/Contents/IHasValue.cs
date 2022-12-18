namespace Minesweeper.Core.Cells.Contents;

public interface IHasValue
{
    public ConsoleColor ForegroundColor { get; }
    
    public ConsoleColor BackGroundColor { get; }
    
    public string Value { get; }
}