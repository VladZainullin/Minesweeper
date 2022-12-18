using Minesweeper.Core.Cells;
using Minesweeper.Core.Cells.Contents;
using Minesweeper.Core.Cells.Coordinates;
using Minesweeper.Core.Cells.States;
using Minesweeper.Core.Commons.CellGenerators;
using Minesweeper.Core.Extensions;
using Minesweeper.Core.Games.Difficulties;

namespace Minesweeper.Core.CellGenerators;

public sealed class CellGenerator : IGenerator
{
    private readonly IDifficulty _difficulty;

    public CellGenerator(IDifficulty difficulty)
    {
        _difficulty = difficulty;
    }
    
    private static readonly Random Random = new();
    
    private readonly List<Cell> _cells = new();

    public IEnumerable<Cell> Generate()
    {
        GenerateBombCells();
        GenerateSpaceAndNumberCells();

        return _cells;
    }

    private void GenerateBombCells()
    {
        var bombContent = new BombContent();
        var closeState = new CloseState();
        
        foreach (var _ in _difficulty.CountOfBomb - 1)
        {
            while (true)
            {
                var coordinate = GetRandomCoordinate(_difficulty.Weight, _difficulty.Height);

                var exists = CheckExistsCell(coordinate);
                if (exists)
                {
                    continue;
                }

                var cell = new Cell(coordinate, closeState, bombContent);
                
                _cells.Add(cell);
                
                break;
            }
        }
    }
    
    private void GenerateSpaceAndNumberCells()
    {
        var spaceContent = new SpaceContent();
        var closeState = new CloseState();
        
        foreach (var _ in _difficulty.Weight * _difficulty.Height - _difficulty.CountOfBomb - 1)
        {
            while (true)
            {
                var coordinate = GetRandomCoordinate(_difficulty.Weight, _difficulty.Height);

                var exists = CheckExistsCell(coordinate);
                if (exists)
                {
                    continue;
                }

                var countOfBombAround = GetCountOfBombAround(coordinate);
                IHasValue content = countOfBombAround != 0
                    ? new NumberContent(countOfBombAround)
                    : spaceContent;

                var cell = new Cell(coordinate, closeState, content);
                
                _cells.Add(cell);
                
                break;
            }
        }
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