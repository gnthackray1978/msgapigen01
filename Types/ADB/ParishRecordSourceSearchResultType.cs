using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ParishRecordSourceSearchResultType : ObjectGraphType<ParishRecordSourceSearchResult>
    {
        public ParishRecordSourceSearchResultType() {
            Field(m => m.Id);
            Field(m => m.RecordTypeName);
            Field(m => m.RecordTypeDescription);
        }
    }


    public class ParishRecordSourceSearchResult
    {
        public int Id { get; set; }
        public string RecordTypeName { get; set; }
        public string RecordTypeDescription { get; set; }
    }
}
 