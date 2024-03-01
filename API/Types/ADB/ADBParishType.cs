using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBParishType : ObjectType<ADBParish>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParish> descriptor)
        {

           descriptor.Field(m => m.Id);

           descriptor.Field(m => m.ParishName);
           descriptor.Field(m => m.ParishRegistersDeposited);
           descriptor.Field(m => m.ParishNotes);
           descriptor.Field(m => m.ParentParish);
           descriptor.Field(m => m.ParishStartYear);
           descriptor.Field(m => m.ParishEndYear);
           descriptor.Field(m => m.ParishCounty);
           descriptor.Field(m => m.ParishX);
           descriptor.Field(m => m.ParishY);
        }

    }
}