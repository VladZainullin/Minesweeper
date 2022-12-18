namespace Minesweeper.Core.Games.Difficulties;

public class DifficultyFactory
{
    public IDifficulty Get(int index)
    {
        return index switch
        {
            1 => new EasyDifficulty(),
            2 => new NormalDifficulty(),
            3 => new HardDifficulty(),
            _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
        };
    }
}