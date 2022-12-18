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

    public GameStatus Status
    {
        get
        {
            var allBombMark = CheckAllBombMark();

            var allBombClose = CheckAllBombClose();

            return (allBombMark, allBombClose) switch
            {
                (false, true) => GameStatus.Progress,
                (_, false) => GameStatus.GameOver,
                (true, true) => GameStatus.Win
            };
        }
    }

    public event EventHandler<CellOpenEventArgs>? ChangeCell;

    private bool CheckAllBombMark()
    {
        return _cells
            .Where(c => c.ContentIs<BombContent>())
            .All(c => c.StateIs<MarkState>());
    }

    private bool CheckAllBombClose()
    {
        return _cells
            .Where(c => c.ContentIs<BombContent>())
            .All(c => !c.StateIs<OpenState>());
    }

    public void ChangeCellState(ICoordinate coordinate, ICellState state)
    {
        var cell = _cells.Single(c => c.InCoordinate(coordinate));
        cell.TransitionTo(state);
        OnOpenCell(new CellOpenEventArgs(_cells));
    }

    private void OnOpenCell(CellOpenEventArgs e)
    {
        ChangeCell?.Invoke(this, e);
    }
}

public enum GameStatus
{
    Progress = 1,
    GameOver,
    Win
}