using Minesweeper.Core.Cells.Contents;

namespace Minesweeper.Core.Cells.States;

public interface ICellState
{
    string GetContent(IHasValue hasValue);
}