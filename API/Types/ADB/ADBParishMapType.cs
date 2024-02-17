using Api.Models;
using HotChocolate.Types;
using System;

namespace Api.Types.ADB
{
    public class ADBParishMapType : ObjectType<ADBParishMap>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParishMap> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.SourceMappingParishId);
           descriptor.Field(m => m.SourceMappingSourceId);
           descriptor.Field(m => m.SourceMappingDateAdded);
           descriptor.Field(m => m.SourceMappingUser);
            
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
 