using Minesweeper.Core.Boards;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
using Minesweeper.Core.Printers;

namespace Minesweeper.Core.Games;

public sealed class Game
{
    private readonly Board _board;
    private readonly IPrintable _printable;

    public Game(Board board, IPrintable printable)
    {
        _printable = printable;
        _board = board;
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