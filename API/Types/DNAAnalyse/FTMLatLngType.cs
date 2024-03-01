using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

namespace Api.Types.DNAAnalyse;

public class FTMLatLngType : ObjectType<FTMLatLng>
{
    protected override void Configure(IObjectTypeDescriptor<FTMLatLng> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.Lat);
        descriptor.Field(m => m.Long);
        descriptor.Field(m => m.Weight);     
    }
}