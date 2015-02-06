using System;
using System.Collections.Generic;

namespace webapilab.entities.Queries.Result
{
    public class QueryResult<T>
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int TotalPageCount
        {
            get
            {
                return (int)Math.Ceiling(Count / (double)PageSize);
            }
        }

        public IEnumerable<T> Data { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPageCount);
            }
        }
    }
}