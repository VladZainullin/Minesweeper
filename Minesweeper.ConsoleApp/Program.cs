using Minesweeper.Core.Boards;
using Minesweeper.Core.CellGenerators;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
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

        var game = new Game(board);
        _ = new ConsolePrinter(game);

        while (game.Status == GameStatus.Progress)
        {
            var (x, y, state) = InputData();

            var coordinate = new Coordinate(x, y);

            game.TryChangeCell(coordinate, state);
        }

        if (game.Status == GameStatus.GameOver)
        {
            Console.WriteLine("Game over");
            return;
        }

        Console.WriteLine("You are win");
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

    private static (int x, int y, ICellState state) InputData()
    {
        while (true)
        {
            Console.Write("Input x, y, open/mark (o/m): ");
            var tuple = Console.ReadLine();

            var parse = int.TryParse(tuple?.Split()[0], out var x);
            if (!parse) continue;

            var tryParse = int.TryParse(tuple?.Split()[1], out var y);
            if (!tryParse) continue;

            var stateShortTitle = tuple?.Split().Last();
            if (stateShortTitle != "o" && stateShortTitle != "m") continue;
            var state = GetCellState(stateShortTitle);

            return (x, y, state);
        }
    }

    private static ICellState GetCellState(string shortTitle)
    {
        return shortTitle switch
        {
            "o" => new OpenState(),
            "m" => new MarkState()
        };
    }
}