using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBParishRecType : ObjectType<ADBParishRec>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParishRec> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.ParishId);
           descriptor.Field(m => m.DataTypeId);
           descriptor.Field(m => m.Year);
           descriptor.Field(m => m.RecordType);
           descriptor.Field(m => m.OriginalRegister);
           descriptor.Field(m => m.YearEnd);
        }
    }
}
