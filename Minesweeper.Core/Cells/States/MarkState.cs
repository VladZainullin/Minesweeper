using Minesweeper.Core.Cells.Contents;

namespace Minesweeper.Core.Cells.States;

public class MarkState : ICellState
{
    public string GetContent(IHasValue hasValue)
    {
        return "F";
    }
}