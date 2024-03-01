using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.Wills;

namespace Api.Models;

public class WillType : ObjectType<Will>
{
    protected override void Configure(IObjectTypeDescriptor<Will> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.DateString);
        descriptor.Field(m => m.Url);
        descriptor.Field(m => m.Description);
        descriptor.Field(m => m.Collection);
        descriptor.Field(m => m.Reference);
        descriptor.Field(m => m.Place);
        descriptor.Field(m => m.Year);

        descriptor.Field(m => m.Typ);
        descriptor.Field(m => m.FirstName);
        descriptor.Field(m => m.Surname);
        descriptor.Field(m => m.Occupation);

        descriptor.Field(m => m.Aliases);
        descriptor.Field(m => m.Error);

    }
}