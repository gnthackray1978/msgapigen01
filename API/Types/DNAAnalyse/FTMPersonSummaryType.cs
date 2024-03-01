using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class FTMPersonSummaryType : ObjectType<FTMPersonSummary>
{
    protected override void Configure(IObjectTypeDescriptor<FTMPersonSummary> descriptor)
    {
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.TreeName);
        descriptor.Field(x => x.FirstName);
        descriptor.Field(x => x.Surname);
        descriptor.Field(x => x.YearStart);
        descriptor.Field(x => x.YearEnd);
    }
}