namespace Minesweeper.Core.Cells.Coordinates;

public interface ICoordinate : IEquatable<ICoordinate>
{
    public int X { get; }

    public int Y { get; }
}