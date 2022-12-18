namespace Minesweeper.Core.Cells.Contents;

public sealed class NumberContent : IHasValue
{
    private readonly int _number;

    public NumberContent(int number)
    {
        _number = number;
    }

    public ConsoleColor ForegroundColor => default;

    public ConsoleColor BackGroundColor => default;
    public string Value => _number.ToString();
}