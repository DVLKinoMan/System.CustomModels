using static System.Net.Mime.MediaTypeNames;

namespace System.CustomModels.Filters
{
    public class PatternString<T>(string propPath, string? displayName = null, string? value = null, string? pattern = null)
        : Filter<T>(propPath, displayName) where T : class
    {
        public string? Value { get; set; } = value;
        public string? Pattern { get; set; } = pattern;

        public override FilterType FilterType => FilterType.PatternString;

        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);

        public override bool IsValid => !string.IsNullOrEmpty(Value) || !string.IsNullOrEmpty(Pattern);

        public override void Reset()
        {
            Value = null;
            Pattern = null;
        }

        public override string ToString() => 
            BaseToString() + 
            (!string.IsNullOrEmpty(Value) ? $"{DisplayName} == {Value}"
            : !string.IsNullOrEmpty(Pattern) ? $"{DisplayName}.Contains({Pattern})" : string.Empty);

        public override Filter<T> Clone() =>
             new PatternString<T>(PropertyPath, DisplayName, Value, Pattern)
             {
                 FilterOperator = FilterOperator
             };
    }
}
