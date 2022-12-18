using Minesweeper.Core.Cells.Contents;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;

namespace Minesweeper.Core.Cells;

public sealed class Cell
{
    private readonly IHasValue _content;
    private readonly ICoordinate _coordinate;
    private ICellState _state;

    public Cell(
        ICoordinate coordinate,
        ICellState state,
        IHasValue content)
    {
        _coordinate = coordinate;
        _state = state;
        _content = content;
    }

    public int X => _coordinate.X;

    public int Y => _coordinate.Y;

    public void TransitionTo(ICellState content)
    {
        _state = content;
    }

    public bool ContentIs<T>() where T : IHasValue
    {
        return _content is T;
    }

    public bool StateIs<T>() where T : ICellState
    {
        return _state is T;
    }

    public bool InCoordinate(ICoordinate coordinate)
    {
        return _coordinate.Equals(coordinate);
    }

    public override string ToString()
    {
        return _state.GetContent(_content);
    }
}