namespace Minesweeper.Core.Games.Printers;

public class ConsolePrinter
{
    public ConsolePrinter(Game game)
    {
        game.OpenCell += Print;
    }

    private static void Print(object? sender, CellOpenEventArgs e)
    {
        Console.WriteLine(e.Cells.ToString());
    }
}