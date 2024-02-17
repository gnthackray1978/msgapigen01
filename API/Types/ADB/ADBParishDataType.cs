using Api.Models;
using HotChocolate.Types;

namespace Api.Types.ADB
{
    public class ADBParishDataType : ObjectType<ADBParishData>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParishData> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.ParishId);
           descriptor.Field(m => m.ParishDataString);
        }
    }

    public class ADBParishData
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string ParishDataString { get; set; }

    }
}
 