using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ParishRecordsSearchResultType : ObjectGraphType<ParishRecordsSearchResult>
    {
        public ParishRecordsSearchResultType() {
            Field(m => m.Id);
            Field(m => m.ParishId);
            Field(m => m.DataTypeId);
            Field(m => m.Year);
            Field(m => m.RecordType);
            Field(m => m.OriginalRegister);
            Field(m => m.YearEnd);
        }
    }

    public class ParishRecordsSearchResult
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public int DataTypeId { get; set; }
        public int Year { get; set; }
        public string RecordType { get; set; }
        public bool OriginalRegister { get; set; }
        public int YearEnd { get; set; }
    }
}
