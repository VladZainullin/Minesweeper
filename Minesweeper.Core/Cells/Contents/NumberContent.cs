namespace Minesweeper.Core.Cells.Contents;

public sealed class NumberContent : IHasValue
{
    public NumberContent(int number)
    {
        Value = number.ToString();
    }

    public string Value { get; }
}