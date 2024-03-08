using System.ComponentModel;

namespace System.CustomModels.Filters
{
    [TypeConverter(typeof(FilterTypeConverter))]
    public abstract class Filter
    {
        public FilterType FilterType { get; set; }
        public string? PropertyPath { get; set; }
        public FilterOperator FilterOperator { get; set; } = default;

        public abstract void Accept(ISelectVisitor visitor);
    }
}
