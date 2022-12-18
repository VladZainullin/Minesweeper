using Minesweeper.Core.Cells;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
using Minesweeper.Core.Games.Printers;

namespace Minesweeper.Core.Games;

public sealed class Game
{
    private readonly IEnumerable<Cell> _cells;
    private readonly IPrintable _printable;

    public Game(IEnumerable<Cell> cells, IPrintable printable)
    {
        _printable = printable;
        _cells = cells;
    }

    public bool TryOpenCell(ICoordinate coordinate, ICellState state)
    {
        var exists = _cells.Any(c => c.InCoordinate(coordinate));
        if (exists)
        {
            var cell = _cells.Single(c => c.InCoordinate(coordinate));
            cell.TransitionTo(state);
        }

        return exists;
    }

    public void Print()
    {
        _printable.Print();
    }
}