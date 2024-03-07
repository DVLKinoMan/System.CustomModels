namespace System.CustomModels.Filters
{
    public class ExactValueFilter<TValue> : Filter
    {
        public TValue Value { get; set; }
        public override void Accept(ISelectVisitor visitor) => visitor.Accept(this);
    }
}
