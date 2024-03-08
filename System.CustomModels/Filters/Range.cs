namespace System.CustomModels.Filters
{
    public class Range<TValue>(TValue? st = null, TValue? end = null, bool includingEnds = true) 
        where TValue : struct
    {
        public TValue? Start { get; set; } = st;
        public TValue? End { get; set; } = end;
        public bool IncludingEnds { get; set; } = includingEnds;

        public FilterType FilterType => FilterType.Range;
    }

    public class Range<T, TValue>(TValue? st = null, TValue? end = null, bool includingEnds = true) : Filter<T> where T : class
        where TValue : struct
    {
        public TValue? Start { get; set; } = st;
        public TValue? End { get; set; } = end;
        public bool IncludingEnds { get; set; } = includingEnds;

        public override FilterType FilterType => FilterType.Range;
        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);
    }
}
