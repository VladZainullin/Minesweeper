namespace Minesweeper.Core.Cells.Coordinates;

public readonly record struct Coordinate(int X, int Y) : ICoordinate
{
    public bool Equals(ICoordinate? other)
    {
        return X == other?.X && Y == other.Y;
    }
}