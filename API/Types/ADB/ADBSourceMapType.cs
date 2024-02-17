using Api.Models;
using HotChocolate.Types;
using System;

namespace Api.Types.ADB
{
    public class ADBSourceMapType : ObjectType<ADBSourceMap>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBSourceMap> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.SourceId);
           descriptor.Field(m => m.MarriageRecordId);
           descriptor.Field(m => m.PersonRecordId);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.MapTypeId);
        }
    }
    public class ADBSourceMap
    {
        public int Id { get; set; }
        public int? SourceId { get; set; }
        public int? MarriageRecordId { get; set; }
        public int? PersonRecordId { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? MapTypeId { get; set; }
    }
}
