using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class FTMViewType : ObjectType<FTMView>
{
    protected override void Configure(IObjectTypeDescriptor<FTMView> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.PersonId);
        descriptor.Field(m => m.FirstName);
        descriptor.Field(m => m.Surname);        
        descriptor.Field(m => m.Origin);
        descriptor.Field(m => m.YearStart);
        descriptor.Field(m => m.YearEnd);

        descriptor.Field(m => m.Location);
        descriptor.Field(m => m.BirthLat);
        descriptor.Field(m => m.BirthLong);

        descriptor.Field(m => m.AltLocationDesc);
        descriptor.Field(m => m.AltLocation);

        descriptor.Field(m => m.AltLat);
        descriptor.Field(m => m.AltLong);
        descriptor.Field(m => m.DirectAncestor);
    }
}