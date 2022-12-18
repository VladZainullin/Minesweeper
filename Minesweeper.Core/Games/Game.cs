using Minesweeper.Core.Cells;
using Minesweeper.Core.Cells.Contents;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;

namespace Minesweeper.Core.Games;

public sealed class Game
{
    private readonly IEnumerable<Cell> _cells;

    public Game(IEnumerable<Cell> cells)
    {
        _cells = cells;
    }

    public event EventHandler<CellOpenEventArgs>? ChangeCell;

    public bool TryOpenCell(ICoordinate coordinate, ICellState state)
    {
        var exists = _cells.Any(c => c.InCoordinate(coordinate));
        if (exists)
        {
            var cell = _cells.Single(c => c.InCoordinate(coordinate));
            cell.TransitionTo(state);
            OnOpenCell(new CellOpenEventArgs(_cells));
        }

        return exists;
    }

    public bool InProgress()
    {
        var allBombMark = _cells
            .Where(c => c.ContentIs<BombContent>())
            .All(c => c.StateIs<MarkState>());

        var allBombNotOpen = _cells
            .Where(c => c.ContentIs<BombContent>())
            .All(c => !c.StateIs<OpenState>());

        return !allBombMark && allBombNotOpen;
    }

    private void OnOpenCell(CellOpenEventArgs e)
    {
        ChangeCell?.Invoke(this, e);
    }
}