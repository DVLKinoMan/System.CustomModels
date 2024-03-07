namespace System.CustomModels.Filters
{
    public abstract class Filter
    {
        public string? PropertyPath { get; set; }
        public FilterOperator FilterOperator { get; set; } = default;

        public abstract void Accept(ISelectVisitor visitor);
    }
}
