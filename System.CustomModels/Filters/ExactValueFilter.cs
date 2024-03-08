namespace System.CustomModels.Filters
{
    public class ExactValueFilter<T, TValue> : Filter<T> where T : class
    {
        public TValue Value { get; set; }

        public override FilterType FilterType => FilterType.ExactValue;
        public override void Accept(ISelectVisitor<T> visitor) => visitor.Accept(this);
    }
}
