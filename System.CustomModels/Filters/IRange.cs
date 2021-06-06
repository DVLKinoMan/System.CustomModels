namespace System.CustomModels.Filters
{
    public interface IRange<TValue>
    {
        public TValue Start { get; set; }
        public TValue End { get; set; }
        public bool IncludingEnds { get; set; }
    }
}
