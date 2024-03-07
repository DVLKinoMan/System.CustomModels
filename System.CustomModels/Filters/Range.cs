namespace System.CustomModels.Filters
{
    public class Range<TValue>(TValue st, TValue end, bool includingEnds = true) : Filter 
        where TValue : IComparable<TValue>
    {
        public TValue Start { get; set; } = st;
        public TValue End { get; set; } = end;
        public bool IncludingEnds { get; set; } = includingEnds;
        public override void Accept(ISelectVisitor visitor) => visitor.Accept(this);
    }
}
