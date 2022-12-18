using Minesweeper.Core.Cells;

namespace Minesweeper.Core.CellGenerators;

public interface IGenerator
{
    IEnumerable<Cell> Generate();
}