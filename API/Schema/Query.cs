using Api.Models;
using Api.Schema.SubQueries;

namespace Api.Schemas
{

    public class Query
    {
        public string SiteQuery() => "site";
        public string ClaimQuery() => "claim";
        public string SiteFunctionQuery() => "function";
        public string WillQuery() => "will";
        public string DNAQuery() => "dna";
        public string ADBQuery() => "adb";
        public string ImageQuery() => "image";
        public string DiagramQuery() => "diagram";
        public string BlogQuery() => "blog";
    }
}