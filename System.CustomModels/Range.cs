namespace System.CustomModels
{
    public class Range<TValue>
    {
        public readonly TValue Start;
        public readonly TValue End;
        public readonly bool IncludingEnds;

        public Range(TValue start, TValue end, bool includingEnds = true)
        {
            this.Start = start;
            this.End = end;
            this.IncludingEnds = includingEnds;
        }
    }
}
