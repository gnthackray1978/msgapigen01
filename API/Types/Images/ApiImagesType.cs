using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.Images;

namespace Api.Types.Images
{
    public class ApiImagesType : ObjectType<ApiImage>
    {
        protected override void Configure(IObjectTypeDescriptor<ApiImage> descriptor)
        {
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.Path);
            descriptor.Field(m => m.Title);
            descriptor.Field(m => m.Info);
            descriptor.Field(m => m.ParentImageId);
        }
    }
}
