using static System.Net.Mime.MediaTypeNames;

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

    public class Range<T, TValue>(string propPath, string? displayName = null, TValue? st = null, TValue? end = null, bool includingEnds = true) 
        : Filter<T>(propPath, displayName) where T : class where TValue : struct
    {
        public TValue? Start { get; set; } = st;
        public TValue? End { get; set; } = end;
        public bool IncludingEnds { get; set; } = includingEnds;

        public override FilterType FilterType => FilterType.Range;
        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);

        public override bool IsValid => Start != null || End != null;

        public override void Reset()
        {
            Start = null;
            End = null;
        }

        public override string ToString() =>
            BaseToString() +
            (Start == null
            ? (IncludingEnds ? $"{DisplayName} <= {End}" : $"< {End}")
            : (End == null
               ? (IncludingEnds ? $"{DisplayName} >= {Start}" : $"{DisplayName} > {Start}")
               : (IncludingEnds ? $"{Start} <= {DisplayName} <= {End}" : $"{Start} < {DisplayName} < {End}"))
            );

        public override Filter<T> Clone() =>
             new Range<T, TValue>(PropertyPath, DisplayName, Start, End, IncludingEnds)
             {
                 FilterOperator = FilterOperator
             };
    }
}
