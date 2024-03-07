using System.Collections.Generic;

namespace System.CustomModels.Filters
{
    public class Query
    {
        public List<Filter> Filters { get; set; } = [];

        public List<OrderBy> OrderBy { get; set; } = [];

        //public SelectControlFlags? SelectControlFlags { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }

    public record OrderBy(string Value, bool Asc = true);
}
