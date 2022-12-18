using Minesweeper.Core.Cells;

namespace Minesweeper.Core.Games;

public record CellOpenEventArgs(IEnumerable<Cell> Cells);