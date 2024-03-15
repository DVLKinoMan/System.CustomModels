namespace System.CustomModels
{
    public class Range<TValue>(TValue? st = null, TValue? end = null, bool includingEnds = true)
       where TValue : struct
    {
        public TValue? Start { get; set; } = st;
        public TValue? End { get; set; } = end;
        public bool IncludingEnds { get; set; } = includingEnds;
    }
}
