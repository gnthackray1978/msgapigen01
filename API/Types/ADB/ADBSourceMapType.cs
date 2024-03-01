using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

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
}
