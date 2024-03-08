namespace System.CustomModels.Filters
{
    public class DatetimePattern<T>(string propPath, string? displayName = null) 
        : Filter<T>(propPath, displayName) where T : class
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public override FilterType FilterType => FilterType.DatetimePattern;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);
    }
}
