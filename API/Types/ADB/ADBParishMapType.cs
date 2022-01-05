using GraphQL.Types;
using System;

namespace Api.Types.ADB
{
    public class ADBParishMapType : ObjectGraphType<ADBParishMap>
    {
        public ADBParishMapType() {
            Field(m => m.Id);
            Field(m => m.SourceMappingParishId);
            Field(m => m.SourceMappingSourceId);
            Field(m => m.SourceMappingDateAdded);
            Field(m => m.SourceMappingUser);
            
        }
    }

    public class ADBParishMap
    {
        public int Id { get; set; }
        public int? SourceMappingParishId { get; set; }
        public int? SourceMappingSourceId { get; set; }
        public DateTime? SourceMappingDateAdded { get; set; }
        public int? SourceMappingUser { get; set; }
    }
}
 