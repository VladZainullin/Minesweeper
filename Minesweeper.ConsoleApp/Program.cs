using Minesweeper.Core.Boards;
using Minesweeper.Core.CellGenerators;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Games;
using Minesweeper.Core.Games.Difficulties;
using Minesweeper.Core.Games.Printers;

namespace Minesweeper.ConsoleApp;

internal static class Program
{
    private static void Main()
    {
        var difficulties = GetDifficulties();
        var selectableDifficulty = SelectDifficulty(difficulties);

        var generator = new CellGenerator(selectableDifficulty);

        var cells = generator.Generate();
        var board = new Board(cells);

        var printer = new ConsolePrinter(board);
        var game = new Game(board, printer);

        while (true)
        {
            game.Print();

            var x = Input("Input X: ");
            var y = Input("Input Y: ");

            var coordinate = new Coordinate(x, y);

            if (game.TryOpenCell(coordinate)) continue;
        }
    }

    private static IReadOnlyList<IDifficulty> GetDifficulties()
    {
        return new IDifficulty[]
        {
            new EasyDifficulty(),
            new NormalDifficulty(),
            new HardDifficulty()
        };
    }

    private static IDifficulty SelectDifficulty(
        IReadOnlyList<IDifficulty> difficulties)
    {
        var number = 0;

        Console.WriteLine("Difficulties: ");
        foreach (var difficulty in difficulties)
        {
            var title = difficulty.Title;

            ++number;

            Console.WriteLine($"{number}. {title}");
        }

        var difficultyIndex = Input("Select difficulty : ");
        var selectableDifficulty = difficulties[--difficultyIndex];

        return selectableDifficulty;
    }

    private static int Input(string beforeMessage = "", string errorMessage = "Incorrect input")
    {
        while (true)
        {
            Console.Write(beforeMessage);
            if (int.TryParse(Console.ReadLine(), out var result) && result >= 0) return result;

            Console.WriteLine(errorMessage);
        }
    }
}