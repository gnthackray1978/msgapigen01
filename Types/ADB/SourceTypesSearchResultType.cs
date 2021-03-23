using GraphQL.Types;

namespace Api.Types.ADB
{
    public class SourceTypesSearchResultType : ObjectGraphType<SourceTypesSearchResult>
    {
        public SourceTypesSearchResultType()
        {
            Field(m => m.Id);
            Field(m => m.SourceTypeDesc);
            Field(m => m.SourceDateAdded);
        }
    }

    public class SourceTypesSearchResult
    {
        public int Id { get; set; }
        public string SourceTypeDesc { get; set; }
        public string SourceDateAdded { get; set; }
    }
}
