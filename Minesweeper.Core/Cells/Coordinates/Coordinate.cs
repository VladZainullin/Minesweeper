namespace Minesweeper.Core.Cells.Coordinates;

public record struct Coordinate(int X, int Y) : ICoordinate
{
    public readonly bool Equals(ICoordinate? other)
    {
        return X == other?.X && Y == other.Y;
    }
}