using Minesweeper.Core.Boards;
using Minesweeper.Core.Cells;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
using Minesweeper.Core.Games.Printers;

namespace Minesweeper.Core.Games;

public sealed class Game
{
    private readonly IEnumerable<Cell> _board;
    private readonly IPrintable _printable;

    public Game(IEnumerable<Cell> cells, IPrintable printable)
    {
        _printable = printable;
        _board = cells;
    }

    public bool TryOpenCell(ICoordinate coordinate)
    {
        var exists = _board.Any(c => c.InCoordinate(coordinate));
        if (exists)
        {
            var cell = _board.Single(c => c.InCoordinate(coordinate));
            cell.TransitionTo(new OpenState());
        }

        return exists;
    }

    public void Print()
    {
        _printable.Print();
    }
}