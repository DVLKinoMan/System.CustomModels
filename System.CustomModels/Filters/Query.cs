using System.Collections.Generic;

namespace System.CustomModels.Filters
{
    public abstract class Query
    {
        protected abstract IEnumerable<Filter> Filters { get; }

        //public SelectControlFlags? SelectControlFlags { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        //todo sorting
    }
}
