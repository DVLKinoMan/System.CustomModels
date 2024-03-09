namespace System.CustomModels.Filters
{
    public class ExactValueFilter<T, TValue>(string propPath, string? displayName = null) 
        : Filter<T>(propPath, displayName) where T : class
    {
        public TValue? Value { get; set; }

        public override FilterType FilterType => FilterType.ExactValue;
        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);

        public override bool IsValid => Value != null;

        public override void Reset()
        {
            Value = default;
        }

        public override string ToString() => $"== {Value}" + (FilterOperator == FilterOperator.None ? "" : " " + FilterOperator.ToString());
    }
}
