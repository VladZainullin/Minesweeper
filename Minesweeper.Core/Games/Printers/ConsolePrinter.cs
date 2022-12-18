using Minesweeper.Core.Boards;
using Minesweeper.Core.Cells;

namespace Minesweeper.Core.Games.Printers;

public class ConsolePrinter : IPrintable
{
    private readonly IEnumerable<Cell> _board;

    public ConsolePrinter(IEnumerable<Cell> board)
    {
        _board = board;
    }

    public void Print()
    {
        Console.WriteLine(_board.ToString());
    }
}