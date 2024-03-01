using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class FTMPersonLocationType : ObjectType<FTMPersonLocation>
{
    protected override void Configure(IObjectTypeDescriptor<FTMPersonLocation> descriptor)
    {
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.BirthLat);
        descriptor.Field(x => x.BirthLong);
        descriptor.Field(x => x.LocationName);

        //   descriptor.Field<List<FTMPersonSummaryType>>("ftmPersonSummary");
    }
}