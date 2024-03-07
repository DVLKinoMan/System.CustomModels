using System.Collections.Generic;

namespace System.CustomModels.Filters
{
    public interface ISelectVisitor : IDisposable
    {
        string ToString();
        IEnumerable<(string, string, object)> GetParameters();
        //void Accept(FilmSelectControlFlags selectControlFlags);
        //void Accept(FilmOrderBy orderBy, bool ascending = true);
        void Accept<TRes>(ExactValueFilter<TRes> filter);
        void Accept<TRes>(Range<TRes> rangeFilter) where TRes : IComparable<TRes>;
        void Accept(PatternString patternString);
        void Accept(DatetimePattern datetimePattern);
        void Accept(string orderBy, bool @ascending = true);
    }
}
