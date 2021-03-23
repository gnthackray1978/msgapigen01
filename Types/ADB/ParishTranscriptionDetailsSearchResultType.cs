using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ParishTranscriptionDetailsSearchResultType : ObjectGraphType<ParishTranscriptionDetailsSearchResult>
    {
        public ParishTranscriptionDetailsSearchResultType()
        {
            Field(m => m.Id);
            Field(m => m.ParishId);
            Field(m => m.ParishDataString);
        }
    }

    public class ParishTranscriptionDetailsSearchResult
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string ParishDataString { get; set; }

    }
}
 