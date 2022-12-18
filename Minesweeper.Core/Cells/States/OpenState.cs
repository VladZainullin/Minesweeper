using Minesweeper.Core.Cells.Contents;

namespace Minesweeper.Core.Cells.States;

public sealed class OpenState : ICellState
{
    public string GetContent(IHasValue hasValue)
    {
        return hasValue.Value;
    }
}