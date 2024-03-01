using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

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
}
 