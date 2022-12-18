namespace Minesweeper.Core.Extensions;

public static class EnumeratorExtensions
{
    public static CustomIntEnumerator GetEnumerator(this Range range)
    {
        return new CustomIntEnumerator(range);
    }

    public static CustomIntEnumerator GetEnumerator(this int number)
    {
        return new CustomIntEnumerator(new Range(0, number));
    }

    public ref struct CustomIntEnumerator
    {
        private readonly int _end;

        public CustomIntEnumerator(Range range)
        {
            if (range.End.IsFromEnd) throw new NotSupportedException();

            Current = range.Start.Value - 1;
            _end = range.End.Value;
        }

        public int Current { get; private set; }

        public bool MoveNext()
        {
            return ++Current <= _end;
        }
    }
}