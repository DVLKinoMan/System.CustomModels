using System.Collections.Generic;

namespace System.CustomModels.Filters
{
    public interface ISelectVisitor<T> : IDisposable where T : class
    {
        string ToString();
        IEnumerable<(string, string, object)> GetParameters();
        //void Accept(FilmSelectControlFlags selectControlFlags);
        //void Accept(FilmOrderBy orderBy, bool ascending = true);
        void Accept<TRes>(ExactValueFilter<T, TRes> filter);
        void Accept<TRes>(Range<T, TRes> rangeFilter) where TRes : struct;
        void Accept(PatternString<T> patternString);
        void Accept(DatetimePattern<T> datetimePattern);
        void Accept(string orderBy, bool @ascending = true);
    }
}
