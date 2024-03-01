using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBRecSourceType : ObjectType<ADBRecSource>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBRecSource> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.RecordTypeName);
           descriptor.Field(m => m.RecordTypeDescription);
        }
    }
}
 