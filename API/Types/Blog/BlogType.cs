using HotChocolate.Types;

namespace Api.Types.Blog;

public class BlogType : ObjectType<MSGSharedData.Domain.Entities.NonPersistent.Blog.Blog>
{
    protected override void Configure(IObjectTypeDescriptor<MSGSharedData.Domain.Entities.NonPersistent.Blog.Blog> descriptor)
    {
        descriptor.Field(m => m.Id);

        descriptor.Field(m => m.Text);
        descriptor.Field(m => m.Level);
        descriptor.Field(m => m.Title);
        descriptor.Field(m => m.LinkURL);
        descriptor.Field(m => m.LinkDescription);
        descriptor.Field(m => m.ImageURL);
        descriptor.Field(m => m.ImageDescription);
        descriptor.Field(m => m.DateLastEdit);
    }
}