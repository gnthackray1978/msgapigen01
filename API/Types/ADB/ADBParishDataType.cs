using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBParishDataType : ObjectType<ADBParishData>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParishData> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.ParishId);
           descriptor.Field(m => m.ParishDataString);
        }
    }
}
 