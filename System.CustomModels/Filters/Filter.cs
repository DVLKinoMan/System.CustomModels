using System.ComponentModel;

namespace System.CustomModels.Filters
{
    [TypeConverter(typeof(FilterTypeConverter))]
    public abstract class Filter<T>(string propPath, string? displayName = null) where T : class
    {
        private string? _displayName = displayName;
        public abstract FilterType FilterType { get; }
        public string PropertyPath { get; set; } = propPath;
        public string? DisplayName { get => _displayName ?? PropertyPath.Split('.')[^1]; private set => _displayName = value; }
        public FilterOperator FilterOperator { get; set; } = default;

        public abstract void Accept(ISelectVisitor<T> visitor);
        public abstract void Reset();
        public abstract override string ToString();
        public abstract Filter<T> Clone();

        public abstract bool IsValid { get; }
    }
}
