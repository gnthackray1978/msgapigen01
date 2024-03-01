using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class PersonOfInterestType : ObjectType<PersonOfInterestSubset>
{
    protected override void Configure(IObjectTypeDescriptor<PersonOfInterestSubset> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.PersonId);
        descriptor.Field(m => m.ChristianName);
        descriptor.Field(m => m.Surname);
        descriptor.Field(m => m.BirthYear);
        descriptor.Field(m => m.BirthPlace);
        descriptor.Field(m => m.BirthCounty);
        descriptor.Field(m => m.BirthCountry);
        descriptor.Field(m => m.TestDisplayName);
        descriptor.Field(m => m.TestAdminDisplayName);
        descriptor.Field(m => m.TreeUrl);
        descriptor.Field(m => m.TestGuid);
        descriptor.Field(m => m.Confidence);
        descriptor.Field(m => m.SharedCentimorgans);
        descriptor.Field(m => m.CreatedDate);
        descriptor.Field(m => m.RootsEntry);
        descriptor.Field(m => m.Memory);
        descriptor.Field(m => m.KitId);
        descriptor.Field(m => m.Name);
    }
}