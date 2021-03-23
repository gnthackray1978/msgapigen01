using GraphQL.Types;
using System;

namespace Api.Types.ADB
{
    public class SourceMappingsSearchResultType : ObjectGraphType<SourceMappingsSearchResult>
    {
        public SourceMappingsSearchResultType()
        {
            Field(m => m.Id);
            Field(m => m.SourceId);
            Field(m => m.MarriageRecordId);
            Field(m => m.PersonRecordId);
            Field(m => m.DateAdded);
            Field(m => m.MapTypeId);
        }
    }
    public class SourceMappingsSearchResult
    {
        public int Id { get; set; }
        public int? SourceId { get; set; }
        public int? MarriageRecordId { get; set; }

        public int? PersonRecordId { get; set; }

        public DateTime? DateAdded { get; set; }
        public int? MapTypeId { get; set; }
    }
}
