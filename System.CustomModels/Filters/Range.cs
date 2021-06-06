namespace System.CustomModels.Filters
{
    public class Range<TValue> : IRange<TValue>
    {
        public TValue Start { get; set; }
        public TValue End { get; set; }
        public bool IncludingEnds { get; set; }

        public Range(TValue st, TValue end, bool includingEnds = true)
        {
            Start = st;
            End = end;
            IncludingEnds = includingEnds;
        }
    }
}
