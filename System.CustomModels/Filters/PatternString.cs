namespace System.CustomModels.Filters
{
    public class PatternString(string? value = null, string? pattern = null) : Filter
    {
        public string? Value { get; set; } = value;
        public string? Pattern { get; set; } = pattern;

        public override void Accept(ISelectVisitor visitor) => visitor.Accept(this);
    }
}
