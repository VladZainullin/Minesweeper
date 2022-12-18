using Minesweeper.Core.Cells;

namespace Minesweeper.Core.Games.Printers;

public class ConsolePrinter
{
    private IEnumerable<Cell> _cells = default!;

    public ConsolePrinter(Game game)
    {
        game.ChangeCell += Print;
    }

    private void Print(object? sender, CellOpenEventArgs e)
    {
        _cells = e.Cells;

        var weight = GetWeight();
        var height = GetHeight();

        Console.Write("   | ");

        for (var i = 0; i < weight; i++) Console.Write($"{i} ");

        Console.WriteLine();
        Console.Write("---+");
        Console.WriteLine(new string('-', weight * 2));

        for (var x = 0; x < weight; x++)
        {
            Console.Write($" {x} | ");

            for (var y = 0; y < height; y++)
            {
                var cell = GetCell(x, y);

                Console.Write($"{cell} ");
            }

            Console.WriteLine();
        }
    }

    private int GetWeight()
    {
        return GetGroupCount(c => c.X);
    }

    private int GetHeight()
    {
        return GetGroupCount(c => c.Y);
    }

    private int GetGroupCount(Func<Cell, int> selectable)
    {
        return _cells.GroupBy(selectable).Count();
    }

    private Cell GetCell(int x, int y)
    {
        return _cells.Single(c => c.X == x && c.Y == y);
    }
}