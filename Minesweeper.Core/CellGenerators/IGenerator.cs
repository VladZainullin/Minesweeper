using Minesweeper.Core.Cells;

namespace Minesweeper.Core.Commons.CellGenerators;

public interface IGenerator
{
    IEnumerable<Cell> Generate();
}