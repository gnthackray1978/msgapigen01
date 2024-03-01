using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.Images;

namespace Api.Types.Images;

public class ApiParentImagesType : ObjectType<ApiParentImages>
{
    protected override void Configure(IObjectTypeDescriptor<ApiParentImages> descriptor)
    {
        descriptor.Field(m => m.Id);

        descriptor.Field(m => m.Title);
        descriptor.Field(m => m.Info);
        descriptor.Field(m => m.From);
        descriptor.Field(m => m.To);
        descriptor.Field(m => m.Page);
    }
}