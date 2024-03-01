using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class DupeType : ObjectType<Dupe>
{
    protected override void Configure(IObjectTypeDescriptor<Dupe> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.PersonId);
        descriptor.Field(m => m.FirstName);
        descriptor.Field(m => m.Surname);

        descriptor.Field(m => m.Ident);
        descriptor.Field(m => m.Origin);
        descriptor.Field(m => m.Location);

        descriptor.Field(m => m.YearStart);
        descriptor.Field(m => m.YearEnd);


    }
}