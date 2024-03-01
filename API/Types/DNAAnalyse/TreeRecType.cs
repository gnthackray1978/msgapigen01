using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class TreeRecType : ObjectType<TreeRec>
{
    protected override void Configure(IObjectTypeDescriptor<TreeRec> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.Name);
        descriptor.Field(m => m.Origin);
        descriptor.Field(m => m.PersonCount);
        descriptor.Field(m => m.CM);
        descriptor.Field(m => m.Located);
        descriptor.Field(m => m.GroupNumber);
    }
}