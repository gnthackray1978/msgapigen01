using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBISourceType : ObjectType<ADBInternalSourceType>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBInternalSourceType> descriptor)
        {
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.SourceTypeDesc);
            descriptor.Field(m => m.SourceDateAdded);
        }
    }
}
