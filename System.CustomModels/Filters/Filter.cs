using System.ComponentModel;

namespace System.CustomModels.Filters
{
    [TypeConverter(typeof(FilterTypeConverter))]
    public abstract class Filter<T> where T : class
    {
        public FilterType FilterType { get; set; }
        public string? PropertyPath { get; set; }
        public FilterOperator FilterOperator { get; set; } = default;

        public abstract void Accept(ISelectVisitor<T> visitor);
    }
}
