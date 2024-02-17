using Api.Models;
using HotChocolate.Types;

namespace Api.Types.ADB
{
    public class ADBRecSourceType : ObjectType<ADBRecSource>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBRecSource> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.RecordTypeName);
           descriptor.Field(m => m.RecordTypeDescription);
        }
    }


    public class ADBRecSource
    {
        public int Id { get; set; }
        public string RecordTypeName { get; set; }
        public string RecordTypeDescription { get; set; }
    }
}
 