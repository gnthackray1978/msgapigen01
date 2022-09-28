using System.Collections.Generic;

namespace Api.Schema
{
    public class Results<T>
    {
        public IEnumerable<T> results { get; set; }
        public int Page { get; set; }

        public int total_results { private get; set; }
        public int TotalResults => total_results;

        public int total_pages { private get; set; }
        public int TotalPages => total_pages;

        public string Error { get; set; }

        public string LoginInfo { get; set; }

    }
}