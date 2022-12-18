using System.Collections;
using System.Text;
using Minesweeper.Core.Cells;

namespace Minesweeper.Core.Boards;

public sealed class Board : IEnumerable<Cell>
{
    private readonly List<Cell> _cells;

    public Board(IEnumerable<Cell> cells)
    {
        _cells = new List<Cell>(cells);
    }

    IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
    {
        return _cells.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _cells.GetEnumerator();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        var weight = GetWeight();
        var height = GetHeight();

        for (var x = 0; x < weight; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var cell = GetCell(x, y);

                builder.Append(cell);
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private int GetWeight()
    {
        return _cells.GroupBy(c => c.X).Count() - 1;
    }

    private int GetHeight()
    {
        return _cells.GroupBy(c => c.Y).Count() - 1;
    }

    private Cell GetCell(int x, int y)
    {
        return _cells.Single(c => c.X == x && c.Y == y);
    }
}