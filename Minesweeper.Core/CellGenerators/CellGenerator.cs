using Minesweeper.Core.Cells;
using Minesweeper.Core.Cells.Contents;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
using Minesweeper.Core.Games.Difficulties;

namespace Minesweeper.Core.CellGenerators;

public sealed class CellGenerator : IGenerator
{
    private static readonly Random Random = new();

    private readonly ICollection<Cell> _cells;
    private readonly IDifficulty _difficulty;

    public CellGenerator(IDifficulty difficulty)
    {
        _difficulty = difficulty;
        _cells = new List<Cell>(difficulty.Height * difficulty.Weight);
    }

    public IEnumerable<Cell> Generate()
    {
        GenerateCells(_difficulty.CountOfBomb, CreateBombCellCell);
        GenerateCells(_difficulty.Weight * _difficulty.Height - _difficulty.CountOfBomb, CreateNotBombCell);

        return _cells;
    }

    private void GenerateCells(int count, Func<ICoordinate, ICellState, Cell> createCell)
    {
        var state = new CloseState();

        for (var i = 0; i < count; i++)
            while (true)
            {
                var coordinate = GetRandomCoordinate(_difficulty.Weight, _difficulty.Height);

                var exists = CheckExistsCell(coordinate);
                if (exists) continue;

                var cell = createCell(coordinate, state);

                _cells.Add(cell);

                break;
            }
    }

    private static Cell CreateBombCellCell(ICoordinate coordinate, ICellState state)
    {
        var bombContent = new BombContent();

        return new Cell(coordinate, state, bombContent);
    }

    private Cell CreateNotBombCell(ICoordinate coordinate, ICellState state)
    {
        var countOfBombAround = GetCountOfBombAround(coordinate);
        IHasValue content = countOfBombAround != 0
            ? new NumberContent(countOfBombAround)
            : new SpaceContent();

        return new Cell(coordinate, state, content);
    }

    private static ICoordinate GetRandomCoordinate(int weight, int height)
    {
        var x = Random.Next(weight);
        var y = Random.Next(height);

        return new Coordinate(x, y);
    }

    private int GetCountOfBombAround(ICoordinate coordinate)
    {
        var result = 0;

        for (var i = -1; i < 2; i++)
        for (var j = -1; j < 2; j++)
        {
            var exists = CheckExistsCell<BombContent>(coordinate.X + i, coordinate.Y + j);
            if (exists) result += 1;
        }

        return result;
    }

    private bool CheckExistsCell(ICoordinate coordinate)
    {
        return _cells.Any(c => c.InCoordinate(coordinate));
    }

    private bool CheckExistsCell<T>(int x, int y) where T : IHasValue
    {
        return _cells.Any(c =>
            c.X == x
            &&
            c.Y == y
            &&
            c.ContentIs<T>());
    }
}