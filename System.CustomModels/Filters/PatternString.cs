namespace System.CustomModels.Filters
{
    public class PatternString<T>(string propPath, string? displayName = null, string? value = null, string? pattern = null)
        : Filter<T>(propPath, displayName) where T : class
    {
        public string? Value { get; set; } = value;
        public string? Pattern { get; set; } = pattern;

        public override FilterType FilterType => FilterType.PatternString;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);
    }
}
