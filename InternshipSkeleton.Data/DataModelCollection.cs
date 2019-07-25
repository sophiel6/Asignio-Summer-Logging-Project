using System;
using System.Collections.Generic;
using System.Linq;

namespace AsignioInternship.Data
{
    public class DataModelCollection<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
    
    public class PagedDataModelCollection<T> : DataModelCollection<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }

        public string SortBy { get; set; }
        public string SearchBy { get; set; }
        public string SearchInput { get; set; }

    }
}