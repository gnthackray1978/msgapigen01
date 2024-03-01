using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{
    public class ADBSourceType : ObjectType<ADBSource>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBSource> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.SourceRef);
           descriptor.Field(m => m.SourceDate);
           descriptor.Field(m => m.SourceDateTo);
           descriptor.Field(m => m.SourceDateStr);
           descriptor.Field(m => m.SourceDateStrTo);
           descriptor.Field(m => m.SourceDescription);
           descriptor.Field(m => m.OriginalLocation);
           descriptor.Field(m => m.IsCopyHeld);
           descriptor.Field(m => m.IsViewed);
           descriptor.Field(m => m.IsThackrayFound);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.UserId);
           descriptor.Field(m => m.SourceNotes);
           descriptor.Field(m => m.SourceFileCount);
        }
    }
}
