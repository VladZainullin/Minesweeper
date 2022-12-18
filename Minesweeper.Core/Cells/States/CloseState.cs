using Minesweeper.Core.Cells.Contents;

namespace Minesweeper.Core.Cells.States;

public sealed class CloseState : ICellState
{
    public string GetContent(IHasValue hasValue)
    {
        return "_";
    }
}