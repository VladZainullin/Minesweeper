using Minesweeper.Core.Boards;

namespace Minesweeper.Core.Games.Difficulties;

public interface IDifficulty
{
    string Title { get; }
    
    int CountOfBomb { get; }
    
    int Weight { get; }
    
    int Height { get; }
}