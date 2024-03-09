namespace System.CustomModels.Filters
{
    public class PatternString<T>(string propPath, string? displayName = null, string? value = null, string? pattern = null)
        : Filter<T>(propPath, displayName) where T : class
    {
        public string? Value { get; set; } = value;
        public string? Pattern { get; set; } = pattern;

        public override FilterType FilterType => FilterType.PatternString;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);

        public override bool IsValid => Value != null || Pattern != null;

        public override void Reset()
        {
            Value = null;
            Pattern = null;
        }

        public override string ToString() => (Value != null ? $"== {Value}"
            : Pattern != null ? $"Contains({Pattern})" : string.Empty)
            + (FilterOperator == FilterOperator.None ? "" : " " + FilterOperator.ToString());
    }
}
