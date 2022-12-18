using Minesweeper.Core.Boards;

namespace Minesweeper.Core.Games.Printers;

public class ConsolePrinter : IPrintable
{
    private readonly Board _board;

    public ConsolePrinter(Board board)
    {
        _board = board;
    }

    public void Print()
    {
        Console.WriteLine(_board.ToString());
    }
}